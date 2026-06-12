namespace Opzenix.Modules.Reviews.Application.Queries.GetReviews;

public sealed class GetReviewsResponse
{
    public Guid Id { get; init; }

    public Guid PullRequestId { get; init; }

    public string Status { get; init; } = string.Empty;

    public int FilesAnalyzed { get; init; }

    public int FindingsCount { get; init; }

    public string? Summary { get; init; }

    public DateTime CreatedAtUtc { get; init; }
}