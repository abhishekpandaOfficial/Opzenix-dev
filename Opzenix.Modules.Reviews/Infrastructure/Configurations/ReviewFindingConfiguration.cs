using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Infrastructure.Configurations;

public sealed class ReviewFindingConfiguration
    : IEntityTypeConfiguration<ReviewFinding>
{
    public void Configure(
        EntityTypeBuilder<ReviewFinding> builder)
    {
        builder.ToTable("review_findings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
            .HasColumnType("text");

        builder.Property(x => x.Category)
            .HasColumnType("text");

        builder.Property(x => x.Message)
            .HasColumnType("text");

        builder.Property(x => x.Recommendation)
            .HasColumnType("text");
    }
}