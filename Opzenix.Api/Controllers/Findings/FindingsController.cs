using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Reviews.Application.Queries.GetFindings;

namespace Opzenix.Api.Controllers.Findings;

[ApiController]
[Route("api/findings")]
public sealed class FindingsController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public FindingsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? severity,
        [FromQuery] string? category,
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetFindingsQuery(
                    severity,
                    category),
                cancellationToken);

        return Ok(response);
    }
}