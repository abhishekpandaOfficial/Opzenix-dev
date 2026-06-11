using MediatR;
using Opzenix.Modules.Identity.Contracts.Responses;

namespace Opzenix.Modules.Identity.Application.Queries.GetUserById;

public sealed record GetUserByIdQuery(
    Guid UserId)
    : IRequest<UserResponse>;