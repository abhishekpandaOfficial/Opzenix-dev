using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Repositories.Application.Commands.CreateRepository;
using Opzenix.Modules.Repositories.Contracts.Requests;
using Opzenix.Modules.Repositories.Application.Queries.GetRepositoryById;
using Opzenix.Modules.Repositories.Application.Queries.GetRepositoriesByOrganization;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/repositories")]
public sealed class RepositoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RepositoriesController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateRepositoryRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new CreateRepositoryCommand(
                request.OrganizationId,
                request.Name,
                request.Url,
                request.Provider);

        var result =
            await _mediator.Send(
                command,
                cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetRepositoryByIdQuery(id),
                cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpGet("organization/{organizationId:guid}")]
    public async Task<IActionResult> GetByOrganization(
        Guid organizationId,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetRepositoriesByOrganizationQuery(
                    organizationId),
                cancellationToken);

        return Ok(result);
    }
}