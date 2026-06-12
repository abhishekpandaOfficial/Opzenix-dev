using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubPullRequests;

public sealed class GetGitHubPullRequestsQueryHandler
    : IRequestHandler<
        GetGitHubPullRequestsQuery,
        List<GitHubPullRequestResponse>?>
{
    private readonly GitHubClient _gitHubClient;

    public GetGitHubPullRequestsQueryHandler(
        GitHubClient gitHubClient)
    {
        _gitHubClient = gitHubClient;
    }

    public async Task<List<GitHubPullRequestResponse>?> Handle(
        GetGitHubPullRequestsQuery request,
        CancellationToken cancellationToken)
    {
        return await _gitHubClient.GetPullRequestsAsync(
            request.Owner,
            request.Repository,
            cancellationToken);
    }
}