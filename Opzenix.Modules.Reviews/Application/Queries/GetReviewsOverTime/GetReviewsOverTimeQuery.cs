using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewsOverTime;

public sealed record GetReviewsOverTimeQuery
    : IRequest<List<ReviewsOverTimeResponse>>;