namespace Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

public sealed class TopRepositoryResponse
{
    public Guid RepositoryId { get; init; }

    public string Name { get; init; }
        = string.Empty;

    public int PullRequests { get; init; }

    public int Branches { get; init; }

    public int Commits { get; init; }
}