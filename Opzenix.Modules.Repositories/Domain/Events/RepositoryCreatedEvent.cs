using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Events;

public sealed record RepositoryCreatedEvent(
    Guid RepositoryId)
    : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } =
        DateTime.UtcNow;
}