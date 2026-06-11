namespace Opzenix.Modules.Repositories.Application.Services;

public interface IRepositorySyncService
{
    Task SyncAsync(
        Guid repositoryId,
        CancellationToken cancellationToken);
}