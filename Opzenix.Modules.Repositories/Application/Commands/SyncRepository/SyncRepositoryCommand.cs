using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncRepository;

public sealed record SyncRepositoryCommand(
    Guid RepositoryId)
    : IRequest;