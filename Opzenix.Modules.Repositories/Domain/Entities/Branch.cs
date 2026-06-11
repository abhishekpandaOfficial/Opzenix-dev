using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class Branch : BaseEntity
{
    public Guid RepositoryId { get; private set; }

    public string Name { get; private set; }

    public bool IsDefault { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private Branch()
    {
    }

    public Branch(
        Guid repositoryId,
        string name,
        bool isDefault = false)
    {
        Id = Guid.NewGuid();

        RepositoryId = repositoryId;

        Name = name;

        IsDefault = isDefault;

        CreatedAtUtc = DateTime.UtcNow;
    }
}