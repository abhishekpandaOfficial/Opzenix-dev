using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Identity.Domain.Entities;

namespace Opzenix.Modules.Identity.Infrastructure.Configurations;

public sealed class RoleConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(
        EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(x => x.Id);
    }
}