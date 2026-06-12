using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Application.Interfaces;

public interface IReviewsDbContext
{
    DbSet<Review> Reviews { get; }

    DbSet<ReviewFinding> ReviewFindings { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken);
}