using MediatR;
using Opzenix.Modules.Identity.Contracts.Responses;

namespace Opzenix.Modules.Identity.Application.Commands.AddUserToOrganization;

public sealed record AddUserToOrganizationCommand(
    Guid OrganizationId,
    Guid UserId)
    : IRequest<AddUserToOrganizationResponse>;