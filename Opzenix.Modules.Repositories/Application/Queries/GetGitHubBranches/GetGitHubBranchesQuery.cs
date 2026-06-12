using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubBranches;

public sealed record GetGitHubBranchesQuery(
    string Owner,
    string Repository)
    : IRequest<List<GitHubBranchResponse>?>;