using System.Text.Json;
using Opzenix.BuildingBlocks.AI.Models;

namespace Opzenix.BuildingBlocks.AI.Providers.Gemini.Parsing;

public static class GeminiResponseParser
{
    public static List<AiFinding> Parse(
        string fileName,
        string response)
    {
        try
        {
            var findings =
                JsonSerializer.Deserialize<
                    List<GeminiFindingDto>>(
                    response,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (findings is null)
            {
                return [];
            }

            return findings
                .Select(
                    x => new AiFinding
                    {
                        FileName = fileName,
                        Severity = x.Severity,
                        Category = x.Category,
                        Message = x.Message,
                        Recommendation = x.Recommendation
                    })
                .ToList();
        }
        catch
        {
            return [];
        }
    }
}