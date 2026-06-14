using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Reviews.Application.Queries.GetDashboardActivity;
using Opzenix.Modules.Reviews.Application.Queries.GetDashboardOverview;
using Opzenix.Modules.Reviews.Application.Queries.GetRecentReviews;
using Opzenix.Modules.Reviews.Application.Queries.GetTopRepositories;

namespace Opzenix.Api.Controllers.Dashboard;

[ApiController]
[Route("api/dashboard")]
public sealed class DashboardController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("overview")]
    public async Task<IActionResult> Overview(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetDashboardOverviewQuery(),
                cancellationToken);

        return Ok(response);
    }
    [HttpGet("recent-reviews")]
    public async Task<IActionResult> RecentReviews(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetRecentReviewsQuery(),
                cancellationToken);

        return Ok(response);
    }
    [HttpGet("top-repositories")]
    public async Task<IActionResult> TopRepositories(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetTopRepositoriesQuery(),
                cancellationToken);

        return Ok(response);
    }
    [HttpGet("activity")]
    public async Task<IActionResult> Activity(
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetDashboardActivityQuery(),
                cancellationToken);

        return Ok(response);
    }
}