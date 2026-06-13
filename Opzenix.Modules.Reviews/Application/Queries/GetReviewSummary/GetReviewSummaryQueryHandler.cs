using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewSummary;

public sealed class GetReviewSummaryQueryHandler
    : IRequestHandler<
        GetReviewSummaryQuery,
        ReviewSummaryResponse>
{
    private readonly IReviewsDbContext _dbContext;

    public GetReviewSummaryQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ReviewSummaryResponse> Handle(
        GetReviewSummaryQuery request,
        CancellationToken cancellationToken)
    {
        var review =
            await _dbContext.Reviews
                .FirstAsync(
                    x => x.Id == request.ReviewId,
                    cancellationToken);

        var findings =
            await _dbContext.ReviewFindings
                .Where(
                    x => x.ReviewId == request.ReviewId)
                .ToListAsync(
                    cancellationToken);

        return new ReviewSummaryResponse
        {
            ReviewId = review.Id,

            Status = review.Status,

            ReviewType =
                review.ReviewType.ToString(),

            AiProvider =
                review.AiProvider,

            AiModel =
                review.AiModel,

            FilesAnalyzed =
                review.FilesAnalyzed,

            LinesAnalyzed =
                review.LinesAnalyzed,

            FindingsCount =
                review.FindingsCount,

            HighFindings =
                findings.Count(
                    x => x.Severity == "High"),

            MediumFindings =
                findings.Count(
                    x => x.Severity == "Medium"),

            LowFindings =
                findings.Count(
                    x => x.Severity == "Low")
        };
    }
}