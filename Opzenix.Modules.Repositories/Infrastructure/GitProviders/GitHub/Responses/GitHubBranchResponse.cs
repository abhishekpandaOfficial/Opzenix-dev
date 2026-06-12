using System.Text.Json.Serialization;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

public sealed class GitHubBranchResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}