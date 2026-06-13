namespace Opzenix.Modules.Reviews.Contracts.Responses;

public sealed class ReviewFindingResponse
{
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