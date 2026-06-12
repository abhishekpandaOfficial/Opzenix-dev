using System.Text.Json.Serialization;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

public sealed class GitHubPullRequestFileResponse
{
    [JsonPropertyName("filename")]
    public string FileName { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("additions")]
    public int Additions { get; set; }

    [JsonPropertyName("deletions")]
    public int Deletions { get; set; }

    [JsonPropertyName("changes")]
    public int Changes { get; set; }

    [JsonPropertyName("patch")]
    public string? Patch { get; set; }
}