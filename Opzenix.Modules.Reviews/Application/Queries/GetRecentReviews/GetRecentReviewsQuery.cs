using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetRecentReviews;

public sealed record GetRecentReviewsQuery
    : IRequest<List<RecentReviewResponse>>;