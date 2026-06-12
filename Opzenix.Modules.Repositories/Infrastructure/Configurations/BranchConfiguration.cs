using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Infrastructure.Configurations;

public sealed class BranchConfiguration
    : IEntityTypeConfiguration<Branch>
{
    public void Configure(
        EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(500)
            .IsRequired();
    }
}