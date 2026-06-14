namespace Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

public sealed class RecentReviewResponse
{
    public Guid ReviewId { get; init; }

    public Guid PullRequestId { get; init; }

    public string Status { get; init; }
        = string.Empty;

    public string ReviewType { get; init; }
        = string.Empty;

    public string AiProvider { get; init; }
        = string.Empty;

    public string AiModel { get; init; }
        = string.Empty;

    public int FindingsCount { get; init; }

    public DateTime CreatedAtUtc { get; init; }
}