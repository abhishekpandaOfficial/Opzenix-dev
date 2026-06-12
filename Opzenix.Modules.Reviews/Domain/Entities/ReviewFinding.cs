using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Reviews.Domain.Entities;

public sealed class ReviewFinding : BaseEntity
{
    public Guid ReviewId { get; private set; }

    public string FileName { get; private set; }

    public string Severity { get; private set; }

    public string Category { get; private set; }

    public string Message { get; private set; }

    public string Recommendation { get; private set; }

    private ReviewFinding()
    {
    }

    public ReviewFinding(
        Guid reviewId,
        string fileName,
        string severity,
        string category,
        string message,
        string recommendation)
    {
        Id = Guid.NewGuid();

        ReviewId = reviewId;

        FileName = fileName;

        Severity = severity;

        Category = category;

        Message = message;

        Recommendation = recommendation;
    }
}