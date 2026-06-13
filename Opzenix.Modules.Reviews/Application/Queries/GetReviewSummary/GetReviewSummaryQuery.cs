using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewSummary;

public sealed record GetReviewSummaryQuery(
    Guid ReviewId)
    : IRequest<ReviewSummaryResponse>;