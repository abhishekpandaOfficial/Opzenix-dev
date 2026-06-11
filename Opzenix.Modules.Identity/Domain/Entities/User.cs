using Opzenix.BuildingBlocks.Domain;
using Opzenix.Modules.Identity.Domain.Events;
using Opzenix.Modules.Identity.Domain.ValueObjects;

namespace Opzenix.Modules.Identity.Domain.Entities;

public sealed class User : AggregateRoot
{
    public string Email { get; private set; }

    public string DisplayName { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private User()
    {
    }

    public User(
        string email,
        string displayName)
    {
        Id = Guid.NewGuid();

        Email = email;

        DisplayName = displayName;

        IsActive = true;

        CreatedAtUtc = DateTime.UtcNow;

        AddDomainEvent(
            new UserCreatedEvent(Id));
    }
}