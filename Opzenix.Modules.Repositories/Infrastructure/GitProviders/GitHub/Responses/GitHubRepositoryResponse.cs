using System.Text.Json.Serialization;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

public sealed class GitHubRepositoryResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("default_branch")]
    public string DefaultBranch { get; set; } = string.Empty;

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("stargazers_count")]
    public int Stars { get; set; }

    [JsonPropertyName("forks_count")]
    public int Forks { get; set; }
}