using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class PullRequest : BaseEntity
{
    public Guid RepositoryId { get; private set; }

    public long GitHubId { get; private set; }

    public int Number { get; private set; }

    public string Title { get; private set; }

    public string State { get; private set; }

    public string AuthorName { get; private set; }

    public string Url { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private PullRequest()
    {
    }

    public PullRequest(
        Guid repositoryId,
        long gitHubId,
        int number,
        string title,
        string state,
        string authorName,
        string url)
    {
        Id = Guid.NewGuid();

        RepositoryId = repositoryId;

        GitHubId = gitHubId;

        Number = number;

        Title = title;

        State = state;

        AuthorName = authorName;

        Url = url;

        CreatedAtUtc = DateTime.UtcNow;
    }
}