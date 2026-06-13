using Opzenix.BuildingBlocks.AI.Enums;
using Opzenix.Modules.Reviews.Domain.Enums;

namespace Opzenix.Modules.Reviews.Application.Mappers;

public static class AiReviewTypeMapper
{
    public static AiReviewType Map(
        ReviewType reviewType)
    {
        return reviewType switch
        {
            ReviewType.Security =>
                AiReviewType.Security,

            ReviewType.Performance =>
                AiReviewType.Performance,

            ReviewType.Architecture =>
                AiReviewType.Architecture,

            ReviewType.Maintainability =>
                AiReviewType.Maintainability,

            _ =>
                AiReviewType.General
        };
    }
}