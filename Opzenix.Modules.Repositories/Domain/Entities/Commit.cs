using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class Commit : BaseEntity
{
    public Guid RepositoryId { get; private set; }

    public string Sha { get; private set; }

    public string Message { get; private set; }

    public string AuthorName { get; private set; }

    public DateTime CommittedAtUtc { get; private set; }

    private Commit()
    {
    }

    public Commit(
        Guid repositoryId,
        string sha,
        string message,
        string authorName,
        DateTime committedAtUtc)
    {
        Id = Guid.NewGuid();

        RepositoryId = repositoryId;

        Sha = sha;

        Message = message;

        AuthorName = authorName;

        CommittedAtUtc = committedAtUtc;
    }
}