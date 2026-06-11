using Opzenix.Modules.Repositories.Application.Interfaces;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders;

public sealed class AzureDevOpsProvider
    : IGitProvider
{
    public string ProviderName => "azuredevops";

    public Task SyncRepositoryAsync(
        Guid repositoryId,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}