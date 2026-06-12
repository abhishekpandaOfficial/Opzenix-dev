using MediatR;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed record GetReviewFindingsQuery(
    Guid ReviewId)
    : IRequest<List<GetReviewFindingsResponse>>;