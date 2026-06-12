namespace Opzenix.Modules.Reviews.Application.Queries.GetReviewFindings;

public sealed class GetReviewFindingsResponse
{
    public Guid Id { get; init; }

    public string FileName { get; init; } = string.Empty;

    public string Severity { get; init; } = string.Empty;

    public string Category { get; init; } = string.Empty;

    public string Message { get; init; } = string.Empty;

    public string Recommendation { get; init; } = string.Empty;
}