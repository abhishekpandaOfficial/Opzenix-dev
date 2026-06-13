using Opzenix.BuildingBlocks.AI.Abstractions;

namespace Opzenix.BuildingBlocks.AI.Providers.Factory;

public sealed class AiProviderFactory
    : IAiProviderFactory
{
    private readonly IEnumerable<IAiProvider> _providers;

    public AiProviderFactory(
        IEnumerable<IAiProvider> providers)
    {
        _providers = providers;
    }

    public IAiProvider GetProvider(
        string providerName)
    {
        Console.WriteLine(
            $"Resolving Provider: {providerName}");

        var provider =
            _providers.First(
                x => x.Name.Equals(
                    providerName,
                    StringComparison.OrdinalIgnoreCase));

        Console.WriteLine(
            $"Provider Found: {provider.Name}");

        return provider;
    }
}