namespace Opzenix.BuildingBlocks.Application.Messaging;

public interface IMessageBus
{
    Task PublishAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
        where T : class;
}