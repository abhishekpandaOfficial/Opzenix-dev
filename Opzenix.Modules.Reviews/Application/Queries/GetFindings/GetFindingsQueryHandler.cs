using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses;
using Opzenix.Modules.Reviews.Contracts.Responses.Findings;

namespace Opzenix.Modules.Reviews.Application.Queries.GetFindings;

public sealed class GetFindingsQueryHandler
    : IRequestHandler<
        GetFindingsQuery,
        List<ReviewFindingResponse>>
{
    private readonly IReviewsDbContext _dbContext;

    public GetFindingsQueryHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ReviewFindingResponse>> Handle(
        GetFindingsQuery request,
        CancellationToken cancellationToken)
    {
        var query =
            _dbContext.ReviewFindings
                .AsQueryable();

        if (!string.IsNullOrWhiteSpace(
                request.Severity))
        {
            query =
                query.Where(
                    x => x.Severity ==
                         request.Severity);
        }

        if (!string.IsNullOrWhiteSpace(
                request.Category))
        {
            query =
                query.Where(
                    x => x.Category ==
                         request.Category);
        }

        return await query
            .OrderByDescending(
                x => x.Id)
            .Select(
                x => new ReviewFindingResponse
                {
                    ReviewId = x.ReviewId,
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