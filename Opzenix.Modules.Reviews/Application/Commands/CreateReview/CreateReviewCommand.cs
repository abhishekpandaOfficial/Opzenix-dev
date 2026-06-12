using MediatR;

namespace Opzenix.Modules.Reviews.Application.Commands.CreateReview;

public sealed record CreateReviewCommand(
    Guid PullRequestId)
    : IRequest<Guid>;