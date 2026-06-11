using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Application.Interfaces;

public interface IRepositoryDbContext
{
    DbSet<Repository> Repositories { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken);
}