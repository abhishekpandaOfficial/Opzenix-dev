using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Identity.Application.Commands.CreateUser;
using Opzenix.Modules.Identity.Application.Queries.GetUserById;
using Opzenix.Modules.Identity.Contracts.Requests;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new CreateUserCommand(
                request.Email,
                request.DisplayName);

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
        var user =
            await _mediator.Send(
                new GetUserByIdQuery(id),
                cancellationToken);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}