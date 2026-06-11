using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class PullRequest : BaseEntity
{
    public Guid RepositoryId { get; private set; }

    public int Number { get; private set; }

    public string Title { get; private set; }

    public string Status { get; private set; }

    public string AuthorName { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private PullRequest()
    {
    }

    public PullRequest(
        Guid repositoryId,
        int number,
        string title,
        string status,
        string authorName)
    {
        Id = Guid.NewGuid();

        RepositoryId = repositoryId;

        Number = number;

        Title = title;

        Status = status;

        AuthorName = authorName;

        CreatedAtUtc = DateTime.UtcNow;
    }
}