using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Infrastructure.Persistence;

public sealed class RepositoryDbContext : DbContext, IRepositoryDbContext
{
    public RepositoryDbContext(
        DbContextOptions<RepositoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Repository> Repositories =>
        Set<Repository>();

    public DbSet<Branch> Branches =>
        Set<Branch>();

    public DbSet<Commit> Commits =>
        Set<Commit>();

    public DbSet<PullRequest> PullRequests =>
        Set<PullRequest>();
    
    public DbSet<PullRequestFile> PullRequestFiles =>
        Set<PullRequestFile>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(RepositoryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}