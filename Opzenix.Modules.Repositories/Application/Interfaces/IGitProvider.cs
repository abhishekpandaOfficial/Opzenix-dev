namespace Opzenix.Modules.Repositories.Application.Interfaces;

public interface IGitProvider
{
    string ProviderName { get; }

    Task SyncRepositoryAsync(
        Guid repositoryId,
        CancellationToken cancellationToken);
}