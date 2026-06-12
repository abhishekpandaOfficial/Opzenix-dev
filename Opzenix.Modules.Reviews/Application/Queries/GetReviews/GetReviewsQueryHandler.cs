using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviews;

public sealed class GetReviewsQueryHandler
    : IRequestHandler<
        GetReviewsQuery,
        List<GetReviewsResponse>>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    public GetReviewsQueryHandler(
        IReviewsDbContext reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<List<GetReviewsResponse>> Handle(
        GetReviewsQuery request,
        CancellationToken cancellationToken)
    {
        var query =
            _reviewsDbContext.Reviews
                .AsQueryable();

        if (request.PullRequestId.HasValue)
        {
            query =
                query.Where(
                    x => x.PullRequestId ==
                         request.PullRequestId.Value);
        }

        return await query
            .OrderByDescending(
                x => x.CreatedAtUtc)
            .Select(
                x => new GetReviewsResponse
                {
                    Id = x.Id,
                    PullRequestId = x.PullRequestId,
                    Status = x.Status,
                    FilesAnalyzed = x.FilesAnalyzed,
                    FindingsCount = x.FindingsCount,
                    Summary = x.Summary,
                    CreatedAtUtc = x.CreatedAtUtc
                })
            .ToListAsync(
                cancellationToken);
    }
}