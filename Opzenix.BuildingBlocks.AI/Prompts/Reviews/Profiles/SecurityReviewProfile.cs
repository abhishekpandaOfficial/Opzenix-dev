namespace Opzenix.BuildingBlocks.AI.Prompts.Reviews.Profiles;

public static class SecurityReviewProfile
{
    public const string Instructions =
        """
        Focus on authentication, authorization,
        secrets, injection vulnerabilities,
        insecure deserialization and data exposure.
        """;
}