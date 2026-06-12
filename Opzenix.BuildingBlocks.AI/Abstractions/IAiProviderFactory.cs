namespace Opzenix.BuildingBlocks.AI.Abstractions;

public interface IAiProviderFactory
{
    IAiProvider GetProvider(
        string providerName);
}