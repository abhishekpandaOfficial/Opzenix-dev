using MediatR;

namespace Opzenix.Modules.Reviews.Application.Commands.GenerateReview;

public sealed record GenerateReviewCommand(
    Guid ReviewId)
    : IRequest;