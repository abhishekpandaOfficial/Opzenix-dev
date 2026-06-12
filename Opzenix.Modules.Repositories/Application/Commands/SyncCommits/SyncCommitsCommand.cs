using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncCommits;

public sealed record SyncCommitsCommand(
    Guid RepositoryId,
    Guid BranchId,
    string Owner,
    string Repository,
    string Branch)
    : IRequest;