namespace Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

public sealed class DashboardOverviewResponse
{
    public int Repositories { get; init; }

    public int PullRequests { get; init; }

    public int Reviews { get; init; }

    public int Findings { get; init; }
}