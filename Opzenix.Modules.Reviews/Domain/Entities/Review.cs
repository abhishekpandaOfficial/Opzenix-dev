using Opzenix.BuildingBlocks.Domain;

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

    private Review()
    {
    }

    public Review(Guid pullRequestId)
    {
        Id = Guid.NewGuid();

        PullRequestId = pullRequestId;

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
}