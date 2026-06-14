using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetRecentReviews;

public sealed class GetRecentReviewsQueryHandler
    : IRequestHandler<
        GetRecentReviewsQuery,
        List<RecentReviewResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetRecentReviewsQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<RecentReviewResponse>> Handle(
        GetRecentReviewsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Reviews
            .OrderByDescending(
                x => x.CreatedAtUtc)
            .Take(10)
            .Select(
                x => new RecentReviewResponse
                {
                    ReviewId = x.Id,
                    PullRequestId = x.PullRequestId,

                    Status = x.Status,

                    ReviewType =
                        x.ReviewType.ToString(),

                    AiProvider =
                        x.AiProvider,

                    AiModel =
                        x.AiModel,

                    FindingsCount =
                        x.FindingsCount,

                    CreatedAtUtc =
                        x.CreatedAtUtc
                })
            .ToListAsync(
                cancellationToken);
    }
}