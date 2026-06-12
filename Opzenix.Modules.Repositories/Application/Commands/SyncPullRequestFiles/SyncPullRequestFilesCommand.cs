using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncPullRequestFiles;

public sealed record SyncPullRequestFilesCommand(
    Guid PullRequestId,
    string Owner,
    string Repository,
    int PullRequestNumber)
    : IRequest;