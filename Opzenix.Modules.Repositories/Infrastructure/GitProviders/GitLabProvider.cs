using Opzenix.Modules.Repositories.Application.Interfaces;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders;

public sealed class GitLabProvider
    : IGitProvider
{
    public string ProviderName => "gitlab";

    public Task SyncRepositoryAsync(
        Guid repositoryId,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}