using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubBranches;

public sealed class GetGitHubBranchesQueryHandler
    : IRequestHandler<
        GetGitHubBranchesQuery,
        List<GitHubBranchResponse>?>
{
    private readonly GitHubClient _gitHubClient;

    public GetGitHubBranchesQueryHandler(
        GitHubClient gitHubClient)
    {
        _gitHubClient = gitHubClient;
    }

    public async Task<List<GitHubBranchResponse>?> Handle(
        GetGitHubBranchesQuery request,
        CancellationToken cancellationToken)
    {
        return await _gitHubClient.GetBranchesAsync(
            request.Owner,
            request.Repository,
            cancellationToken);
    }
}