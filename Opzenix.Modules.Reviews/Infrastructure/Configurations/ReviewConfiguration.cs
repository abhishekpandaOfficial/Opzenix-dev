using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Infrastructure.Configurations;

public sealed class ReviewConfiguration
    : IEntityTypeConfiguration<Review>
{
    public void Configure(
        EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .HasMaxLength(100);
        
        builder.Property(x => x.Summary)
            .HasColumnType("text");
    }
}