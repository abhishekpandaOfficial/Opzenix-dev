using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.BuildingBlocks.Application.Events;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken);
}