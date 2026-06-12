using System.Net.Http.Json;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;

public sealed class GitHubClient
{
    private readonly HttpClient _httpClient;

    public GitHubClient(
        HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GitHubRepositoryResponse?> GetRepositoryAsync(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<
            GitHubRepositoryResponse>(
            $"repos/{owner}/{repository}",
            cancellationToken);
    }
    public async Task<List<GitHubBranchResponse>?> GetBranchesAsync(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<
            List<GitHubBranchResponse>>(
            $"repos/{owner}/{repository}/branches",
            cancellationToken);
    }
    public async Task<List<GitHubCommitResponse>?> GetCommitsAsync(
        string owner,
        string repository,
        string branch,
        CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<
            List<GitHubCommitResponse>>(
            $"repos/{owner}/{repository}/commits?sha={branch}",
            cancellationToken);
    }
}