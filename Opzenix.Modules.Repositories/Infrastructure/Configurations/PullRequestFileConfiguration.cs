using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Infrastructure.Configurations;

public sealed class PullRequestFileConfiguration
    : IEntityTypeConfiguration<PullRequestFile>
{
    public void Configure(
        EntityTypeBuilder<PullRequestFile> builder)
    {
        builder.ToTable("pull_request_files");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
            .HasColumnType("text");

        builder.Property(x => x.Status)
            .HasColumnType("text");

        builder.Property(x => x.Patch)
            .HasColumnType("text");
    }
}