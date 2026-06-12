using System.Text.Json.Serialization;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

public sealed class GitHubCommitResponse
{
    [JsonPropertyName("sha")]
    public string Sha { get; set; } = string.Empty;

    [JsonPropertyName("commit")]
    public GitHubCommitInfo Commit { get; set; } = new();
}

public sealed class GitHubCommitInfo
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}