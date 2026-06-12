using System.Text.Json.Serialization;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

public sealed class GitHubPullRequestResponse
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("html_url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("user")]
    public GitHubPullRequestUser User { get; set; } = new();
}

public sealed class GitHubPullRequestUser
{
    [JsonPropertyName("login")]
    public string Login { get; set; } = string.Empty;
}