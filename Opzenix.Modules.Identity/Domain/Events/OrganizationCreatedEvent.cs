using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.Events;

public sealed class OrganizationCreatedEvent : IDomainEvent
{
    public Guid OrganizationId { get; }

    public DateTime OccurredOnUtc { get; }

    public OrganizationCreatedEvent(Guid organizationId)
    {
        OrganizationId = organizationId;
        OccurredOnUtc = DateTime.UtcNow;
    }
}