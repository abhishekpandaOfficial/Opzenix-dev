namespace Opzenix.BuildingBlocks.AI.Providers.Ollama;

public sealed class OllamaRequest
{
    public string Model { get; set; }
        = string.Empty;

    public string Prompt { get; set; }
        = string.Empty;

    public bool Stream { get; set; }
        = false;
}