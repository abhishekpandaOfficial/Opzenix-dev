using MediatR;
using Opzenix.Modules.Repositories.Contracts.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetRepositoryById;

public sealed record GetRepositoryByIdQuery(
    Guid RepositoryId)
    : IRequest<CreateRepositoryResponse?>;