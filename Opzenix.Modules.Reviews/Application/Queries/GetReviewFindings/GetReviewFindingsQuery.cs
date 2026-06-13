using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed record GetReviewFindingsQuery(
    Guid ReviewId)
    : IRequest<List<ReviewFindingResponse>>;