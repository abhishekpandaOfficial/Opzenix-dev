using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Models;

namespace Opzenix.BuildingBlocks.AI.Providers.RuleBased;

public sealed class RuleBasedProvider
    : IAiProvider
{
    public string Name => "RuleBased";
    public string Model => "BuiltIn";

    public Task<AiReviewResponse> ReviewAsync(
        AiReviewRequest request,
        CancellationToken cancellationToken)
    {
        var findings =
            new List<AiFinding>();

        if (request.Content.Length > 1000)
        {
            findings.Add(
                new AiFinding
                {
                    FileName = request.FileName,
                    Severity = "Low",
                    Category = "Maintainability",
                    Message = "Large patch detected",
                    Recommendation =
                        "Consider splitting into smaller PRs"
                });
        }

        if (request.Content.Length > 5000)
        {
            findings.Add(
                new AiFinding
                {
                    FileName = request.FileName,
                    Severity = "Medium",
                    Category = "Maintainability",
                    Message = "Very large patch detected",
                    Recommendation =
                        "Break this change into smaller units"
                });
        }

        if (request.Content.Contains(
                "TODO",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new AiFinding
                {
                    FileName = request.FileName,
                    Severity = "Low",
                    Category = "Maintainability",
                    Message = "TODO detected",
                    Recommendation =
                        "Resolve TODO before merging"
                });
        }

        if (request.Content.Contains(
                "Console.WriteLine",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new AiFinding
                {
                    FileName = request.FileName,
                    Severity = "Medium",
                    Category = "Logging",
                    Message = "Console.WriteLine detected",
                    Recommendation =
                        "Use ILogger instead"
                });
        }

        if (request.Content.Contains(
                "password",
                StringComparison.OrdinalIgnoreCase))
        {
            findings.Add(
                new AiFinding
                {
                    FileName = request.FileName,
                    Severity = "High",
                    Category = "Security",
                    Message = "Possible hardcoded password",
                    Recommendation =
                        "Move secrets to configuration"
                });
        }

        return Task.FromResult(
            new AiReviewResponse
            {
                Findings = findings
            });
    }
}