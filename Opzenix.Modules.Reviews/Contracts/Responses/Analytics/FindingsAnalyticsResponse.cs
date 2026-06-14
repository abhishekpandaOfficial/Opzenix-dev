namespace Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

public sealed class FindingsAnalyticsResponse
{
    public int High { get; init; }

    public int Medium { get; init; }

    public int Low { get; init; }

    public int Security { get; init; }

    public int Performance { get; init; }

    public int Architecture { get; init; }

    public int Maintainability { get; init; }

    public int Reliability { get; init; }

    public int Logging { get; init; }

    public int Testing { get; init; }
}