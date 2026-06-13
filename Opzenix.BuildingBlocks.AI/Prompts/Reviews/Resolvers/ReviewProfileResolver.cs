using Opzenix.BuildingBlocks.AI.Enums;
using Opzenix.BuildingBlocks.AI.Prompts.Reviews.Profiles;

namespace Opzenix.BuildingBlocks.AI.Prompts.Reviews.Resolvers;

public static class ReviewProfileResolver
{
    public static string Resolve(
        AiReviewType reviewType)
    {
        return reviewType switch
        {
            AiReviewType.Security =>
                SecurityReviewProfile.Instructions,

            AiReviewType.Performance =>
                PerformanceReviewProfile.Instructions,

            AiReviewType.Architecture =>
                ArchitectureReviewProfile.Instructions,

            AiReviewType.Maintainability =>
                MaintainabilityReviewProfile.Instructions,

            _ =>
                GeneralReviewProfile.Instructions
        };
    }
}