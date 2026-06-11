using MediatR;
using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.BuildingBlocks.Application.Events;

public sealed class DomainEventDispatcher
    : IDomainEventDispatcher
{
    private readonly IPublisher _publisher;

    public DomainEventDispatcher(
        IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken)
    {
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(
                domainEvent,
                cancellationToken);
        }
    }
}