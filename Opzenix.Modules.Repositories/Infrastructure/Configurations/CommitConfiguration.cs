using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Infrastructure.Configurations;

public sealed class CommitConfiguration
    : IEntityTypeConfiguration<Commit>
{
    public void Configure(
        EntityTypeBuilder<Commit> builder)
    {
        builder.ToTable("commits");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Sha)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Message)
            .HasColumnType("text")
            .IsRequired();
    }
}