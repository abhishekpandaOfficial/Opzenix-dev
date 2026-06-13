using Opzenix.BuildingBlocks.AI.Models;

namespace Opzenix.BuildingBlocks.AI.Abstractions;

public interface IAiProvider
{
    string Name { get; }
    string Model { get; }

    Task<AiReviewResponse> ReviewAsync(
        AiReviewRequest request,
        CancellationToken cancellationToken);
}