using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Identity.Application.Commands.AddUserToOrganization;
using Opzenix.Modules.Identity.Contracts.Requests;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/memberships")]
public sealed class MembershipsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembershipsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        AddUserToOrganizationRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new AddUserToOrganizationCommand(
                request.OrganizationId,
                request.UserId);

        var result =
            await _mediator.Send(
                command,
                cancellationToken);

        return Ok(result);
    }
}