using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Configuration;
using Opzenix.BuildingBlocks.AI.Providers.Factory;
using Opzenix.BuildingBlocks.AI.Providers.RuleBased;
using Opzenix.BuildingBlocks.AI.Providers.Ollama;

namespace Opzenix.BuildingBlocks.AI.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAi(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AiOptions>(
            configuration.GetSection(
                AiOptions.SectionName));
        
        services.Configure<OllamaOptions>(
            configuration.GetSection(
                OllamaOptions.SectionName));
        
        services.AddHttpClient();
        
        services.AddSingleton<IAiProvider,
            RuleBasedProvider>();

        services.AddSingleton<IAiProvider,
            OllamaProvider>();

        services.AddSingleton<IAiProviderFactory,
            AiProviderFactory>();

        return services;
    }
}