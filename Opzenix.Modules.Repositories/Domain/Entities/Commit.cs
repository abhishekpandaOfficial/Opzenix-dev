using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Repositories.Domain.Entities;

public sealed class Commit : BaseEntity
{
    public Guid RepositoryId { get; private set; }

    public Guid BranchId { get; private set; }

    public string Sha { get; private set; }

    public string Message { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }

    private Commit()
    {
    }

    public Commit(
        Guid repositoryId,
        Guid branchId,
        string sha,
        string message)
    {
        Id = Guid.NewGuid();

        RepositoryId = repositoryId;

        BranchId = branchId;

        Sha = sha;

        Message = message;

        CreatedAtUtc = DateTime.UtcNow;
    }
}