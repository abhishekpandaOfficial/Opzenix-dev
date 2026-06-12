using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubCommits;

public sealed record GetGitHubCommitsQuery(
    string Owner,
    string Repository,
    string Branch)
    : IRequest<List<GitHubCommitResponse>?>;