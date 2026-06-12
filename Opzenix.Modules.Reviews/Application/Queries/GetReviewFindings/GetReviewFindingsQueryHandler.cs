using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Reviews.Application.Interfaces;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed class GetReviewFindingsQueryHandler
    : IRequestHandler<
        GetReviewFindingsQuery,
        List<GetReviewFindingsResponse>>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    public GetReviewFindingsQueryHandler(
        IReviewsDbContext reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<List<GetReviewFindingsResponse>> Handle(
        GetReviewFindingsQuery request,
        CancellationToken cancellationToken)
    {
        return await _reviewsDbContext.ReviewFindings
            .Where(
                x => x.ReviewId == request.ReviewId)
            .Select(
                x => new GetReviewFindingsResponse
                {
                    Id = x.Id,
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