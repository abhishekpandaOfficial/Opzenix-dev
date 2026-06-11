using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.Entities;

public sealed class Role : BaseEntity
{
    public string Name { get; private set; }

    private Role()
    {
    }

    public Role(string name)
    {
        Id = Guid.NewGuid();

        Name = name;
    }
}