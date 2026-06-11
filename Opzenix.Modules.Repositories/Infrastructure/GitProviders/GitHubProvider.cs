using Opzenix.Modules.Repositories.Application.Interfaces;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders;

public sealed class GitHubProvider
    : IGitProvider
{
    public string ProviderName => "github";

    public Task SyncRepositoryAsync(
        Guid repositoryId,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}