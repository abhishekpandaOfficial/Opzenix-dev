using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Domain.Entities;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncPullRequests;

public sealed class SyncPullRequestsCommandHandler
    : IRequestHandler<SyncPullRequestsCommand>
{
    private readonly GitHubClient _gitHubClient;

    private readonly IRepositoryDbContext _dbContext;

    public SyncPullRequestsCommandHandler(
        GitHubClient gitHubClient,
        IRepositoryDbContext dbContext)
    {
        _gitHubClient = gitHubClient;
        _dbContext = dbContext;
    }

    public async Task Handle(
        SyncPullRequestsCommand request,
        CancellationToken cancellationToken)
    {
        var pullRequests =
            await _gitHubClient.GetPullRequestsAsync(
                request.Owner,
                request.Repository,
                cancellationToken);

        if (pullRequests is null)
        {
            return;
        }

        var existingIds =
            await _dbContext.PullRequests
                .Where(x =>
                    x.RepositoryId ==
                    request.RepositoryId)
                .Select(x => x.GitHubId)
                .ToHashSetAsync(
                    cancellationToken);

        foreach (var pullRequest in pullRequests)
        {
            if (existingIds.Contains(
                pullRequest.Id))
            {
                continue;
            }

            _dbContext.PullRequests.Add(
                new PullRequest(
                    request.RepositoryId,
                    pullRequest.Id,
                    pullRequest.Number,
                    pullRequest.Title,
                    pullRequest.State,
                    pullRequest.User.Login,
                    pullRequest.Url));
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}