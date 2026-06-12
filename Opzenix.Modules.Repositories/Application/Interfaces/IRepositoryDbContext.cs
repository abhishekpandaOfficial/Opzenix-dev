using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Application.Interfaces;

public interface IRepositoryDbContext
{
    DbSet<Repository> Repositories { get; }
    DbSet<Branch> Branches { get; }
    DbSet<Commit> Commits { get; }
    DbSet<PullRequest> PullRequests { get; }
    DbSet<PullRequestFile> PullRequestFiles { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken);
}