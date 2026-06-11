using Opzenix.BuildingBlocks.Application.Messaging;

namespace Opzenix.BuildingBlocks.Infrastructure.Messaging;

public sealed class RabbitMqMessageBus : IMessageBus
{
    public Task PublishAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
        where T : class
    {
        Console.WriteLine(
            $"Published: {typeof(T).Name}");

        return Task.CompletedTask;
    }
}