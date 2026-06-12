using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Infrastructure.Persistence;

public sealed class ReviewsDbContext : DbContext,IReviewsDbContext
{
    public ReviewsDbContext(
        DbContextOptions<ReviewsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews =>
        Set<Review>();

    public DbSet<ReviewFinding> ReviewFindings =>
        Set<ReviewFinding>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ReviewsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}