using MediatR;
using Opzenix.Modules.Identity.Contracts.Responses;

namespace Opzenix.Modules.Identity.Application.Commands.CreateOrganization;

public sealed record CreateOrganizationCommand(
    string Name,
    string Slug)
    : IRequest<CreateOrganizationResponse>;