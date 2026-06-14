using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewsOverTime;

public sealed class GetReviewsOverTimeQueryHandler
    : IRequestHandler<
        GetReviewsOverTimeQuery,
        List<ReviewsOverTimeResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetReviewsOverTimeQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReviewsOverTimeResponse>> Handle(
        GetReviewsOverTimeQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Reviews
            .GroupBy(
                x => x.CreatedAtUtc.Date)
            .Select(
                g => new ReviewsOverTimeResponse
                {
                    Date = g.Key,
                    Reviews = g.Count()
                })
            .OrderBy(
                x => x.Date)
            .ToListAsync(
                cancellationToken);
    }
}