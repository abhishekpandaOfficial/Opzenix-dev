using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Reviews.Application.Commands.CreateReview;
using Opzenix.Modules.Reviews.Application.Commands.GenerateReview;
using Opzenix.Modules.Reviews.Application.Queries.GetReviewById;
using Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;
using Opzenix.Modules.Reviews.Application.Queries.GetReviews;
using Opzenix.Modules.Reviews.Application.Queries.GetReviewSummary;
using Opzenix.Modules.Reviews.Contracts.Requests;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/reviews")]
public sealed class ReviewsController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateReviewRequest request,
        CancellationToken cancellationToken)
    {
        var reviewId =
            await _mediator.Send(
                new CreateReviewCommand(
                    request.PullRequestId,
                    request.ReviewType),
                cancellationToken);

        return Ok(reviewId);
    }
    [HttpPost("{reviewId:guid}/generate")]
    public async Task<IActionResult> Generate(
        Guid reviewId,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new GenerateReviewCommand(
                reviewId),
            cancellationToken);

        return Ok();
    }
    [HttpGet("{reviewId:guid}")]
    public async Task<IActionResult> GetById(
        Guid reviewId,
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetReviewByIdQuery(
                    reviewId),
                cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{reviewId:guid}/findings")]
    public async Task<IActionResult> GetFindings(
        Guid reviewId,
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetReviewFindingsQuery(
                    reviewId),
                cancellationToken);

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetReviews(
        Guid? pullRequestId,
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetReviewsQuery(
                    pullRequestId),
                cancellationToken);

        return Ok(response);
    }
    
    [HttpGet("{reviewId:guid}/summary")]
    public async Task<IActionResult> GetSummary(
        Guid reviewId,
        CancellationToken cancellationToken)
    {
        var response =
            await _mediator.Send(
                new GetReviewSummaryQuery(
                    reviewId),
                cancellationToken);

        return Ok(response);
    }
}