using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubCommits;

public sealed class GetGitHubCommitsQueryHandler
    : IRequestHandler<
        GetGitHubCommitsQuery,
        List<GitHubCommitResponse>?>
{
    private readonly GitHubClient _gitHubClient;

    public GetGitHubCommitsQueryHandler(
        GitHubClient gitHubClient)
    {
        _gitHubClient = gitHubClient;
    }

    public async Task<List<GitHubCommitResponse>?> Handle(
        GetGitHubCommitsQuery request,
        CancellationToken cancellationToken)
    {
        return await _gitHubClient.GetCommitsAsync(
            request.Owner,
            request.Repository,
            request.Branch,
            cancellationToken);
    }
}