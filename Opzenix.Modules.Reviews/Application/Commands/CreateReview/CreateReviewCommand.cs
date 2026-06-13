using MediatR;
using Opzenix.Modules.Reviews.Domain.Enums;

namespace Opzenix.Modules.Reviews.Application.Commands.CreateReview;

public sealed record CreateReviewCommand(
    Guid PullRequestId,
    ReviewType ReviewType)
    : IRequest<Guid>;