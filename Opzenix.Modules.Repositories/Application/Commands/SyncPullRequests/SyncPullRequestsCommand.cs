using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncPullRequests;

public sealed record SyncPullRequestsCommand(
    Guid RepositoryId,
    string Owner,
    string Repository)
    : IRequest;