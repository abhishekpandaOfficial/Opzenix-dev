using MediatR;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncRepository;

public sealed class SyncRepositoryCommandHandler
    : IRequestHandler<SyncRepositoryCommand>
{
    public Task Handle(
        SyncRepositoryCommand request,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}