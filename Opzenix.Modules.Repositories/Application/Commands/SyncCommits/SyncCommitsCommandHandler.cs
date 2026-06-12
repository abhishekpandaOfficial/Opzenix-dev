using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Domain.Entities;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncCommits;

public sealed class SyncCommitsCommandHandler
    : IRequestHandler<SyncCommitsCommand>
{
    private readonly GitHubClient _gitHubClient;

    private readonly IRepositoryDbContext _dbContext;

    public SyncCommitsCommandHandler(
        GitHubClient gitHubClient,
        IRepositoryDbContext dbContext)
    {
        _gitHubClient = gitHubClient;
        _dbContext = dbContext;
    }

    public async Task Handle(
        SyncCommitsCommand request,
        CancellationToken cancellationToken)
    {
        var commits =
            await _gitHubClient.GetCommitsAsync(
                request.Owner,
                request.Repository,
                request.Branch,
                cancellationToken);

        if (commits is null)
        {
            return;
        }

        var existingShas =
            await _dbContext.Commits
                .Where(x =>
                    x.RepositoryId ==
                    request.RepositoryId)
                .Select(x => x.Sha)
                .ToHashSetAsync(
                    cancellationToken);

        foreach (var commit in commits)
        {
            if (existingShas.Contains(
                    commit.Sha))
            {
                continue;
            }

            _dbContext.Commits.Add(
                new Commit(
                    request.RepositoryId,
                    request.BranchId,
                    commit.Sha,
                    commit.Commit.Message));
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}