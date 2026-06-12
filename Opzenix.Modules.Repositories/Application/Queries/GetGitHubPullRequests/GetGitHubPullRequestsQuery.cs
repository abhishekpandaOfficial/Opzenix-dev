using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubPullRequests;

public sealed record GetGitHubPullRequestsQuery(
    string Owner,
    string Repository)
    : IRequest<List<GitHubPullRequestResponse>?>;