using MediatR;

namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewById;

public sealed record GetReviewByIdQuery(
    Guid ReviewId)
    : IRequest<GetReviewByIdResponse>;