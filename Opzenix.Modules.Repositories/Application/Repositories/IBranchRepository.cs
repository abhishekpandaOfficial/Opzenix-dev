using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Application.Repositories;

public interface IBranchRepository
{
    Task AddRangeAsync(
        List<Branch> branches,
        CancellationToken cancellationToken);
}