using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Domain.Entities;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncPullRequestFiles;

public sealed class SyncPullRequestFilesCommandHandler
    : IRequestHandler<SyncPullRequestFilesCommand>
{
    private readonly GitHubClient _gitHubClient;

    private readonly IRepositoryDbContext _dbContext;

    public SyncPullRequestFilesCommandHandler(
        GitHubClient gitHubClient,
        IRepositoryDbContext dbContext)
    {
        _gitHubClient = gitHubClient;
        _dbContext = dbContext;
    }

    public async Task Handle(
        SyncPullRequestFilesCommand request,
        CancellationToken cancellationToken)
    {
        var files =
            await _gitHubClient.GetPullRequestFilesAsync(
                request.Owner,
                request.Repository,
                request.PullRequestNumber,
                cancellationToken);

        if (files is null)
        {
            return;
        }

        var existingFiles =
            await _dbContext.PullRequestFiles
                .Where(x =>
                    x.PullRequestId ==
                    request.PullRequestId)
                .Select(x => x.FileName)
                .ToHashSetAsync(
                    cancellationToken);

        foreach (var file in files)
        {
            if (existingFiles.Contains(
                file.FileName))
            {
                continue;
            }

            _dbContext.PullRequestFiles.Add(
                new PullRequestFile(
                    request.PullRequestId,
                    file.FileName,
                    file.Status,
                    file.Additions,
                    file.Deletions,
                    file.Changes,
                    file.Patch ?? string.Empty));
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}