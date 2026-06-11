using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Contracts.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetRepositoriesByOrganization;

public sealed class GetRepositoriesByOrganizationQueryHandler
    : IRequestHandler<
        GetRepositoriesByOrganizationQuery,
        List<CreateRepositoryResponse>>
{
    private readonly IRepositoryDbContext _dbContext;

    public GetRepositoriesByOrganizationQueryHandler(
        IRepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CreateRepositoryResponse>> Handle(
        GetRepositoriesByOrganizationQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Repositories
            .Where(x => x.OrganizationId == request.OrganizationId)
            .Select(x =>
                new CreateRepositoryResponse(
                    x.Id,
                    x.OrganizationId,
                    x.Name,
                    x.Url,
                    x.Provider))
            .ToListAsync(cancellationToken);
    }
}