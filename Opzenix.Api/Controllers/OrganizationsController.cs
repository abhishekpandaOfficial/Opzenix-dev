using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Identity.Application.Commands.CreateOrganization;
using Opzenix.Modules.Identity.Contracts.Requests;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/organizations")]
public sealed class OrganizationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateOrganizationRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new CreateOrganizationCommand(
                request.Name,
                request.Slug);

        var result =
            await _mediator.Send(
                command,
                cancellationToken);

        return Ok(result);
    }
}