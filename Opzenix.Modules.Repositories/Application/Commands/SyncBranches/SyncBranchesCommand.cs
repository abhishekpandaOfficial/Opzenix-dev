using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncBranches;

public sealed record SyncBranchesCommand(
    Guid RepositoryId,
    string Owner,
    string Repository)
    : IRequest;