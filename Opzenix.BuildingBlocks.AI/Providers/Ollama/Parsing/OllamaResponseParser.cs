using Opzenix.BuildingBlocks.AI.Models;

namespace Opzenix.BuildingBlocks.AI.Providers.Ollama.Parsing;

public static class OllamaResponseParser
{
    public static List<AiFinding> Parse(
        string fileName,
        string response)
    {
        if (response.Contains(
                "NO_FINDINGS",
                StringComparison.OrdinalIgnoreCase))
        {
            return [];
        }

        var findings =
            new List<AiFinding>();

        var lines =
            response.Split(
                '\n',
                StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var parts =
                line.Split('|');

            if (parts.Length < 4)
            {
                continue;
            }

            findings.Add(
                new AiFinding
                {
                    FileName = fileName,
                    Severity = parts[0].Trim(),
                    Category = parts[1].Trim(),
                    Message = parts[2].Trim(),
                    Recommendation =
                        string.Join(
                            "|",
                            parts.Skip(3))
                });
        }
        Console.WriteLine(
            $"Parser Findings: {findings.Count}");
        return findings;
    }
}