namespace Opzenix.BuildingBlocks.AI.Providers.Ollama;

public sealed class OllamaOptions
{
    public const string SectionName = "Ollama";

    public string BaseUrl { get; set; }
        = "http://localhost:11434";

    public string Model { get; set; }
        = "deepseek-coder:1.3b";
}