using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Opzenix.Modules.Repositories.Infrastructure.Persistence;

public sealed class RepositoryDbContextFactory
    : IDesignTimeDbContextFactory<RepositoryDbContext>
{
    public RepositoryDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<RepositoryDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;" +
            "Port=5432;" +
            "Database=opzenix;" +
            "Username=postgres;" +
            "Password=postgres");

        return new RepositoryDbContext(
            optionsBuilder.Options);
    }
}