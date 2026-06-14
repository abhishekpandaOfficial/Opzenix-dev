using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetDashboardActivity;

public sealed class GetDashboardActivityQueryHandler
    : IRequestHandler<
        GetDashboardActivityQuery,
        List<DashboardActivityResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetDashboardActivityQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DashboardActivityResponse>> Handle(
        GetDashboardActivityQuery request,
        CancellationToken cancellationToken)
    {
        var reviews =
            await _dbContext.Reviews
                .OrderByDescending(
                    x => x.CreatedAtUtc)
                .Take(20)
                .ToListAsync(
                    cancellationToken);

        return reviews
            .Select(
                review =>
                    new DashboardActivityResponse
                    {
                        ActivityType = "Review",

                        Title =
                            $"Review {review.Status}",

                        Description =
                            $"{review.ReviewType} review on PR {review.PullRequestId}",

                        CreatedAtUtc =
                            review.CreatedAtUtc
                    })
            .ToList();
    }
}