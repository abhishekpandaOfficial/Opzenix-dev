using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewById;

public sealed class GetReviewByIdQueryHandler
    : IRequestHandler<GetReviewByIdQuery, GetReviewByIdResponse>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    public GetReviewByIdQueryHandler(
        IReviewsDbContext reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<GetReviewByIdResponse> Handle(
        GetReviewByIdQuery request,
        CancellationToken cancellationToken)
    {
        var review =
            await _reviewsDbContext.Reviews
                .FirstAsync(
                    x => x.Id == request.ReviewId,
                    cancellationToken);

        return new GetReviewByIdResponse
        {
            Id = review.Id,
            PullRequestId = review.PullRequestId,
            Status = review.Status,
            FilesAnalyzed = review.FilesAnalyzed,
            LinesAnalyzed = review.LinesAnalyzed,
            FindingsCount = review.FindingsCount,
            Summary = review.Summary,
            CreatedAtUtc = review.CreatedAtUtc,
            StartedAtUtc = review.StartedAtUtc,
            CompletedAtUtc = review.CompletedAtUtc
        };
    }
}