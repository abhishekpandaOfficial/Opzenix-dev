namespace Opzenix.Modules.Reviews.Contracts.Responses.Findings;

public sealed class ReviewFindingResponse
{
    public Guid ReviewId { get; init; }

    public string FileName { get; init; }
        = string.Empty;

    public string Severity { get; init; }
        = string.Empty;

    public string Category { get; init; }
        = string.Empty;

    public string Message { get; init; }
        = string.Empty;

    public string Recommendation { get; init; }
        = string.Empty;
}