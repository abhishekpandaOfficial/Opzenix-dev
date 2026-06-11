using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Contracts.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetRepositoryById;

public sealed class GetRepositoryByIdQueryHandler
    : IRequestHandler<
        GetRepositoryByIdQuery,
        CreateRepositoryResponse?>
{
    private readonly IRepositoryDbContext _dbContext;

    public GetRepositoryByIdQueryHandler(
        IRepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateRepositoryResponse?> Handle(
        GetRepositoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var repository =
            await _dbContext.Repositories
                .FirstOrDefaultAsync(
                    x => x.Id == request.RepositoryId,
                    cancellationToken);

        if (repository is null)
        {
            return null;
        }

        return new CreateRepositoryResponse(
            repository.Id,
            repository.OrganizationId,
            repository.Name,
            repository.Url,
            repository.Provider);
    }
}