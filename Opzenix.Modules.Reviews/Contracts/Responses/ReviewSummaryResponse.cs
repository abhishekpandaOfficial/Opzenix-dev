namespace Opzenix.Modules.Reviews.Contracts.Responses;

public sealed class ReviewSummaryResponse
{
    public Guid ReviewId { get; init; }

    public string Status { get; init; }
        = string.Empty;

    public string ReviewType { get; init; }
        = string.Empty;

    public string AiProvider { get; init; }
        = string.Empty;

    public string AiModel { get; init; }
        = string.Empty;

    public int FilesAnalyzed { get; init; }

    public int LinesAnalyzed { get; init; }

    public int FindingsCount { get; init; }

    public int HighFindings { get; init; }

    public int MediumFindings { get; init; }

    public int LowFindings { get; init; }
}