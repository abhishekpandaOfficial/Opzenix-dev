namespace Opzenix.BuildingBlocks.AI.Providers.Gemini;

public sealed class GeminiResponse
{
    public List<Candidate>? Candidates { get; set; }
}

public sealed class Candidate
{
    public Content? Content { get; set; }
}

public sealed class Content
{
    public List<Part>? Parts { get; set; }
}

public sealed class Part
{
    public string? Text { get; set; }
}