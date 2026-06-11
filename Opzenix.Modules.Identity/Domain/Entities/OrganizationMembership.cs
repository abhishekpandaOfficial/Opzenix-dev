using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.Entities;

public sealed class OrganizationMembership : BaseEntity
{
    public Guid OrganizationId { get; private set; }

    public Guid UserId { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime JoinedAtUtc { get; private set; }

    private OrganizationMembership()
    {
    }

    public OrganizationMembership(
        Guid organizationId,
        Guid userId)
    {
        Id = Guid.NewGuid();

        OrganizationId = organizationId;

        UserId = userId;

        IsActive = true;

        JoinedAtUtc = DateTime.UtcNow;
    }
}