namespace Opzenix.BuildingBlocks.AI.Configuration;

public sealed class AiOptions
{
    public const string SectionName = "AI";

    public string DefaultProvider { get; set; }
        = "RuleBased";
}