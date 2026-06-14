namespace Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

public sealed class ReviewsOverTimeResponse
{
    public DateTime Date { get; init; }

    public int Reviews { get; init; }
}