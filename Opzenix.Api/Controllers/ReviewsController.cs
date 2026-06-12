using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Reviews.Application.Commands.CreateReview;
using Opzenix.Modules.Reviews.Application.Commands.GenerateReview;
using Opzenix.Modules.Reviews.Application.Queries.GetReviewById;

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
        Guid pullRequestId,
        CancellationToken cancellationToken)
    {
        var reviewId =
            await _mediator.Send(
                new CreateReviewCommand(
                    pullRequestId),
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
}