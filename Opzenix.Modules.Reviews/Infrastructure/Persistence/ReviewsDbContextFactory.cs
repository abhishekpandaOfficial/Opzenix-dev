using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Opzenix.Modules.Reviews.Infrastructure.Persistence;

public sealed class ReviewsDbContextFactory
    : IDesignTimeDbContextFactory<ReviewsDbContext>
{
    public ReviewsDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<ReviewsDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
            "Port=5432;" +
            "Database=opzenix;" +
            "Username=postgres;" +
            "Password=postgres");

        return new ReviewsDbContext(
            optionsBuilder.Options);
    }
}