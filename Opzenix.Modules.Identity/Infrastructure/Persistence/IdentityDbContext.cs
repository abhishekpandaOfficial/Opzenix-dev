using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Identity.Domain.Entities;
using Opzenix.Modules.Identity.Application.Interfaces;

namespace Opzenix.Modules.Identity.Infrastructure.Persistence;

public sealed class IdentityDbContext : DbContext,IIdentityDbContext
{
    public IdentityDbContext(
        DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<User> Users => Set<User>();

    public DbSet<OrganizationMembership> Memberships => Set<OrganizationMembership>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(IdentityDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}