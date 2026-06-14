using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Reviews.Application.Queries.GetFindingsAnalytics;
using Opzenix.Modules.Reviews.Application.Queries.GetProviderAnalytics;
using Opzenix.Modules.Reviews.Application.Queries.GetReviewsOverTime;

namespace Opzenix.Api.Controllers.Analytics;

[ApiController]
[Route("api/analytics")]
public sealed class AnalyticsController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalyticsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("findings")]
    public async Task<IActionResult> Findings(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetFindingsAnalyticsQuery(),
                cancellationToken);

        return Ok(response);
    }
    [HttpGet("providers")]
    public async Task<IActionResult> Providers(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetProviderAnalyticsQuery(),
                cancellationToken);

        return Ok(response);
    }
    [HttpGet("reviews-over-time")]
    public async Task<IActionResult> ReviewsOverTime(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetReviewsOverTimeQuery(),
                cancellationToken);

        return Ok(response);
    }
}