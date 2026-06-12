using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubRepository;

public sealed class GetGitHubRepositoryQueryHandler
    : IRequestHandler<
        GetGitHubRepositoryQuery,
        GitHubRepositoryResponse?>
{
    private readonly GitHubClient _gitHubClient;

    public GetGitHubRepositoryQueryHandler(
        GitHubClient gitHubClient)
    {
        _gitHubClient = gitHubClient;
    }

    public async Task<GitHubRepositoryResponse?> Handle(
        GetGitHubRepositoryQuery request,
        CancellationToken cancellationToken)
    {
        return await _gitHubClient.GetRepositoryAsync(
            request.Owner,
            request.Repository,
            cancellationToken);
    }
}