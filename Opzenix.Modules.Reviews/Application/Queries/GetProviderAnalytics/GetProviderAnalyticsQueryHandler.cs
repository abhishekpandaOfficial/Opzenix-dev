using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetProviderAnalytics;

public sealed class GetProviderAnalyticsQueryHandler
    : IRequestHandler<
        GetProviderAnalyticsQuery,
        List<ProviderAnalyticsResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetProviderAnalyticsQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProviderAnalyticsResponse>> Handle(
        GetProviderAnalyticsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Reviews
            .GroupBy(
                x => x.AiProvider)
            .Select(
                g => new ProviderAnalyticsResponse
                {
                    Provider = g.Key,
                    Reviews = g.Count()
                })
            .OrderByDescending(
                x => x.Reviews)
            .ToListAsync(
                cancellationToken);
    }
}