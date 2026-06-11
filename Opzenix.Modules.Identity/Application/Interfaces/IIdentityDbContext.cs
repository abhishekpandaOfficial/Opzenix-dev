using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Identity.Domain.Entities;

namespace Opzenix.Modules.Identity.Application.Interfaces;

public interface IIdentityDbContext
{
    DbSet<Organization> Organizations { get; }
    DbSet<User> Users { get; }

    DbSet<Role> Roles { get; }

    DbSet<Permission> Permissions { get; }

    DbSet<OrganizationMembership> Memberships { get; }


    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}