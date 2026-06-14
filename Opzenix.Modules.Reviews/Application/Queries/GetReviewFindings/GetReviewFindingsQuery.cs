using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses;
using Opzenix.Modules.Reviews.Contracts.Responses.Findings;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed record GetReviewFindingsQuery(
    Guid ReviewId)
    : IRequest<List<ReviewFindingResponse>>;