namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewById;

public sealed class GetReviewByIdResponse
{
    public Guid Id { get; init; }

    public Guid PullRequestId { get; init; }

    public string Status { get; init; } = string.Empty;

    public int FilesAnalyzed { get; init; }

    public int LinesAnalyzed { get; init; }

    public int FindingsCount { get; init; }

    public string? Summary { get; init; }

    public DateTime CreatedAtUtc { get; init; }

    public DateTime? StartedAtUtc { get; init; }

    public DateTime? CompletedAtUtc { get; init; }
}