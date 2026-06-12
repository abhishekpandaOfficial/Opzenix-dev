using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Infrastructure.Configurations;

public sealed class PullRequestConfiguration
    : IEntityTypeConfiguration<PullRequest>
{
    public void Configure(
        EntityTypeBuilder<PullRequest> builder)
    {
        builder.ToTable("pull_requests");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasColumnType("text");

        builder.Property(x => x.Url)
            .HasColumnType("text");
    }
}