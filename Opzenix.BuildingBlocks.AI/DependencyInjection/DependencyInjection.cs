using Microsoft.Extensions.DependencyInjection;
using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Providers.Factory;
using Opzenix.BuildingBlocks.AI.Providers.RuleBased;

namespace Opzenix.BuildingBlocks.AI.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAi(
        this IServiceCollection services)
    {
        services.AddSingleton<IAiProvider,
            RuleBasedProvider>();

        services.AddSingleton<IAiProviderFactory,
            AiProviderFactory>();

        return services;
    }
}