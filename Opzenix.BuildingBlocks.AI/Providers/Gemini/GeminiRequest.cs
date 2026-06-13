namespace Opzenix.BuildingBlocks.AI.Providers.Gemini;

public sealed class GeminiRequest
{
    public List<GeminiContent> Contents { get; set; }
        = [];
}

public sealed class GeminiContent
{
    public List<GeminiPart> Parts { get; set; }
        = [];
}

public sealed class GeminiPart
{
    public string Text { get; set; }
        = string.Empty;
}