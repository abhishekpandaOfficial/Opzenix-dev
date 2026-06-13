using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed class GetReviewFindingsQueryHandler
    : IRequestHandler<
        GetReviewFindingsQuery,
        List<ReviewFindingResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetReviewFindingsQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReviewFindingResponse>> Handle(
        GetReviewFindingsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.ReviewFindings
            .Where(
                x => x.ReviewId == request.ReviewId)
            .Select(
                x => new ReviewFindingResponse
                {
                    FileName = x.FileName,
                    Severity = x.Severity,
                    Category = x.Category,
                    Message = x.Message,
                    Recommendation = x.Recommendation
                })
            .ToListAsync(
                cancellationToken);
    }
}