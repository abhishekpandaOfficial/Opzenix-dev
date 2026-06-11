using Opzenix.BuildingBlocks.Domain;
using Opzenix.Modules.Repositories.Domain.Events;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class Repository : AggregateRoot
{
    public Guid OrganizationId { get; private set; }

    public string Name { get; private set; }

    public string Url { get; private set; }

    public string Provider { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private Repository()
    {
    }

    public Repository(
        Guid organizationId,
        string name,
        string url,
        string provider)
    {
        Id = Guid.NewGuid();

        OrganizationId = organizationId;

        Name = name;

        Url = url;

        Provider = provider;

        IsActive = true;

        CreatedAtUtc = DateTime.UtcNow;
        AddDomainEvent(
            new RepositoryCreatedEvent(Id));
    }
}