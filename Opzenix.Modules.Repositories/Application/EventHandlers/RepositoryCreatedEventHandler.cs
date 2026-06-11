using MediatR;
using Opzenix.BuildingBlocks.Application.Messaging;
using Opzenix.Modules.Repositories.Contracts.Events;
using Opzenix.Modules.Repositories.Domain.Events;

namespace Opzenix.Modules.Repositories.Application.EventHandlers;

public sealed class RepositoryCreatedEventHandler
    : INotificationHandler<RepositoryCreatedEvent>
{
    private readonly IMessageBus _messageBus;

    public RepositoryCreatedEventHandler(
        IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task Handle(
        RepositoryCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        await _messageBus.PublishAsync(
            new RepositoryCreatedIntegrationEvent(
                notification.RepositoryId),
            cancellationToken);
    }
}