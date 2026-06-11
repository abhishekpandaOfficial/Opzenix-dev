using Microsoft.Extensions.DependencyInjection;
using Opzenix.BuildingBlocks.Application.Messaging;
using Opzenix.BuildingBlocks.Infrastructure.Messaging;

namespace Opzenix.BuildingBlocks;

public static class DependencyInjection
{
    public static IServiceCollection AddBuildingBlocks(
        this IServiceCollection services)
    {
        services.AddSingleton<
            IMessageBus,
            RabbitMqMessageBus>();

        return services;
    }
}