using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.Entities;

public sealed class Permission : BaseEntity
{
    public string Name { get; private set; }

    private Permission()
    {
    }

    public Permission(string name)
    {
        Id = Guid.NewGuid();

        Name = name;
    }
}