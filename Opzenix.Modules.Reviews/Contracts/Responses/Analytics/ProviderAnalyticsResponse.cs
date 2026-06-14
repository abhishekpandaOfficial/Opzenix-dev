namespace Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

public sealed class ProviderAnalyticsResponse
{
    public string Provider { get; init; }
        = string.Empty;

    public int Reviews { get; init; }
}