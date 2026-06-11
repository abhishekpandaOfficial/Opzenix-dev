using Opzenix.BuildingBlocks.Domain;
using Opzenix.Modules.Identity.Domain.Events;
using Opzenix.Modules.Identity.Domain.ValueObjects;

namespace Opzenix.Modules.Identity.Domain.Entities;

public sealed class Organization : AggregateRoot
{
    public string Name { get; private set; }

    public string Slug { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private Organization()
    {
    }

    public Organization(
        string name,
        string slug)
    {
        Id = Guid.NewGuid();

        Name = name;

        Slug = slug;

        IsActive = true;

        CreatedAtUtc = DateTime.UtcNow;

        AddDomainEvent(
            new OrganizationCreatedEvent(Id));
    }
}