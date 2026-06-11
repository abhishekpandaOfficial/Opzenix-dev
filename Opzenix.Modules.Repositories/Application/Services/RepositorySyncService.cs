namespace Opzenix.Modules.Repositories.Application.Services;

public sealed class RepositorySyncService
    : IRepositorySyncService
{
    public Task SyncAsync(
        Guid repositoryId,
        CancellationToken cancellationToken)
    {
        Console.WriteLine(
            $"Syncing repository {repositoryId}");

        return Task.CompletedTask;
    }
}