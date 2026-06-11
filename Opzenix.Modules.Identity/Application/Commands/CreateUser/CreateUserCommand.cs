using MediatR;
using Opzenix.Modules.Identity.Contracts.Responses;

namespace Opzenix.Modules.Identity.Application.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Email,
    string DisplayName)
    : IRequest<CreateUserResponse>;