using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetFindingsAnalytics;

public sealed class GetFindingsAnalyticsQueryHandler
    : IRequestHandler<
        GetFindingsAnalyticsQuery,
        FindingsAnalyticsResponse>
{
    private readonly IReviewsDbContext _dbContext;

    public GetFindingsAnalyticsQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FindingsAnalyticsResponse> Handle(
        GetFindingsAnalyticsQuery request,
        CancellationToken cancellationToken)
    {
        var findings =
            await _dbContext.ReviewFindings
                .ToListAsync(
                    cancellationToken);

        return new FindingsAnalyticsResponse
        {
            High =
                findings.Count(
                    x => x.Severity == "High"),

            Medium =
                findings.Count(
                    x => x.Severity == "Medium"),

            Low =
                findings.Count(
                    x => x.Severity == "Low"),

            Security =
                findings.Count(
                    x => x.Category == "Security"),

            Performance =
                findings.Count(
                    x => x.Category == "Performance"),

            Architecture =
                findings.Count(
                    x => x.Category == "Architecture"),

            Maintainability =
                findings.Count(
                    x => x.Category == "Maintainability"),

            Reliability =
                findings.Count(
                    x => x.Category == "Reliability"),

            Logging =
                findings.Count(
                    x => x.Category == "Logging"),

            Testing =
                findings.Count(
                    x => x.Category == "Testing")
        };
    }
}