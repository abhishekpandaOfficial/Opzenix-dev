using Opzenix.Modules.Reviews.Domain.Enums;

namespace Opzenix.Modules.Reviews.Contracts.Requests;

public sealed class CreateReviewRequest
{
    public Guid PullRequestId { get; init; }

    public ReviewType ReviewType { get; init; }
        = ReviewType.General;
}