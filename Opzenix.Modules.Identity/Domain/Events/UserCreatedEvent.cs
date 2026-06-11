using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.Events;

public sealed class UserCreatedEvent : IDomainEvent
{
    public Guid UserId { get; }

    public DateTime OccurredOnUtc { get; }

    public UserCreatedEvent(Guid userId)
    {
        UserId = userId;
        OccurredOnUtc = DateTime.UtcNow;
    }
}