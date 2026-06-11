using MediatR;
using Opzenix.Modules.Repositories.Contracts.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetRepositoriesByOrganization;

public sealed record GetRepositoriesByOrganizationQuery(
    Guid OrganizationId)
    : IRequest<List<CreateRepositoryResponse>>;