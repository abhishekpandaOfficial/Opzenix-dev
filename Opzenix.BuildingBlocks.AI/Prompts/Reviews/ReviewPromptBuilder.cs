using Opzenix.BuildingBlocks.AI.Enums;
using Opzenix.BuildingBlocks.AI.Prompts.Reviews.Resolvers;

namespace Opzenix.BuildingBlocks.AI.Prompts.Reviews;

public static class ReviewPromptBuilder
{
    public static string Build(
        string fileName,
        string content,
        AiReviewType reviewType)
    {
        var profileInstructions =
            ReviewProfileResolver.Resolve(
                reviewType);
        return $$"""
                 ```

                 You are a senior staff software engineer performing an enterprise-grade pull request review.

                 REVIEW PROFILE

                 {{profileInstructions}}

                 REVIEW OBJECTIVE

                 Analyze ONLY the code provided.

                 Identify:

                 * Security issues
                 * Performance issues
                 * Reliability issues
                 * Architecture violations
                 * Maintainability concerns
                 * Logging issues
                 * Testing gaps

                 STRICT RULES

                 1. Review ONLY the provided code.
                 2. Do NOT invent issues.
                 3. Do NOT assume missing context.
                 4. Report findings only when there is direct evidence.
                 5. If no issues exist, return an empty JSON array.
                 6. Do NOT return markdown.
                 7. Do NOT return explanations.
                 8. Do NOT return code fences.
                 9. Do NOT return introductory text.
                 10. Return VALID JSON only.

                 OUTPUT FORMAT

                 Return ONLY a JSON array.

                 If no findings:

                 []

                 If findings exist:

                 [
                 {
                 "severity": "High",
                 "category": "Security",
                 "message": "Hardcoded password detected",
                 "recommendation": "Move secrets to configuration"
                 }
                 ]

                 Allowed Severities:

                 * Low
                 * Medium
                 * High

                 Allowed Categories:

                 * Security
                 * Performance
                 * Architecture
                 * Maintainability
                 * Reliability
                 * Logging
                 * Testing

                 FILE

                 {{fileName}}

                 CODE

                 {{content}}
                 """;
    }
}