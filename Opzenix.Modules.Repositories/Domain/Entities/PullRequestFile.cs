using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class PullRequestFile : BaseEntity
{
    public Guid PullRequestId { get; private set; }

    public string FileName { get; private set; }

    public string Status { get; private set; }

    public int Additions { get; private set; }

    public int Deletions { get; private set; }

    public int Changes { get; private set; }

    public string Patch { get; private set; }

    private PullRequestFile()
    {
    }

    public PullRequestFile(
        Guid pullRequestId,
        string fileName,
        string status,
        int additions,
        int deletions,
        int changes,
        string patch)
    {
        Id = Guid.NewGuid();

        PullRequestId = pullRequestId;

        FileName = fileName;

        Status = status;

        Additions = additions;

        Deletions = deletions;

        Changes = changes;

        Patch = patch;
    }
}