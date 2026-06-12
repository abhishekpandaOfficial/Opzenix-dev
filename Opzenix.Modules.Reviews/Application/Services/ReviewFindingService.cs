using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Application.Services;

public sealed class ReviewFindingService
{
    public List<ReviewFinding> Analyze(
        Guid reviewId,
        string fileName,
        string patch)
    {
        var findings =
            new List<ReviewFinding>();

        if (patch.Length > 1000)
        {
            findings.Add(
                new ReviewFinding(
                    reviewId,
                    fileName,
                    "Low",
                    "Maintainability",
                    "Large patch detected",
                    "Consider splitting into smaller PRs"));
        }

        if (patch.Length > 5000)
        {
            findings.Add(
                new ReviewFinding(
                    reviewId,
                    fileName,
                    "Medium",
                    "Maintainability",
                    "Very large patch detected",
                    "Break this change into smaller units"));
        }

        if (patch.Contains(
                "TODO",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new ReviewFinding(
                    reviewId,
                    fileName,
                    "Low",
                    "Maintainability",
                    "TODO detected",
                    "Resolve TODO before merging"));
        }

        if (patch.Contains(
                "Console.WriteLine",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new ReviewFinding(
                    reviewId,
                    fileName,
                    "Medium",
                    "Logging",
                    "Console.WriteLine detected",
                    "Use ILogger instead"));
        }

        if (patch.Contains(
                "password",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new ReviewFinding(
                    reviewId,
                    fileName,
                    "High",
                    "Security",
                    "Possible hardcoded password",
                    "Move secrets to configuration"));
        }

        return findings;
    }
}