using Opzenix.BuildingBlocks.Domain;
using Opzenix.Modules.Reviews.Domain.Enums;

namespace Opzenix.Modules.Reviews.Domain.Entities;

public sealed class Review : AggregateRoot
{
    public Guid PullRequestId { get; private set; }

    public string Status { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }
    public string? Summary { get; private set; }
    
    public DateTime? StartedAtUtc { get; private set; }

    public DateTime? CompletedAtUtc { get; private set; }

    public int FilesAnalyzed { get; private set; }

    public int LinesAnalyzed { get; private set; }

    public int FindingsCount { get; private set; }
    public ReviewType ReviewType { get; private set; }
    public string AiProvider { get; private set; }
        = string.Empty;

    public string AiModel { get; private set; }
        = string.Empty;

    private Review()
    {
    }

    public Review(Guid pullRequestId, ReviewType reviewType)
    {
        Id = Guid.NewGuid();

        PullRequestId = pullRequestId;
        ReviewType = reviewType;

        Status = "Pending";

        CreatedAtUtc = DateTime.UtcNow;
    }
    public void MarkCompleted()
    {
        Status = "Completed";
        CompletedAtUtc = DateTime.UtcNow;
    }
    
    public void SetSummary(
        string summary)
    {
        Summary = summary;
    }
    public void MarkStarted()
    {
        Status = "Running";
        StartedAtUtc = DateTime.UtcNow;
    }

    public void SetMetrics(
        int filesAnalyzed,
        int linesAnalyzed,
        int findingsCount)
    {
        FilesAnalyzed = filesAnalyzed;
        LinesAnalyzed = linesAnalyzed;
        FindingsCount = findingsCount;
    }
    public void SetAiMetadata(
        string provider,
        string model)
    {
        AiProvider = provider;
        AiModel = model;
    }
}