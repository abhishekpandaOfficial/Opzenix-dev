using MediatR;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviews;

public sealed record GetReviewsQuery(
    Guid? PullRequestId)
    : IRequest<List<GetReviewsResponse>>;