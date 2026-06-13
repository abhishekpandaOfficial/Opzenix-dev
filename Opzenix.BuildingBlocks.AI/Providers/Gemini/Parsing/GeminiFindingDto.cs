namespace Opzenix.BuildingBlocks.AI.Providers.Gemini.Parsing;

public sealed class GeminiFindingDto
{
    public string Severity { get; set; }
        = string.Empty;

    public string Category { get; set; }
        = string.Empty;

    public string Message { get; set; }
        = string.Empty;

    public string Recommendation { get; set; }
        = string.Empty;
}