using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Reviews.Domain.Entities;

public sealed class Review : AggregateRoot
{
    public Guid PullRequestId { get; private set; }

    public string Status { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }
    public string? Summary { get; private set; }

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
    }
    public void SetSummary(
        string summary)
    {
        Summary = summary;
    }
}