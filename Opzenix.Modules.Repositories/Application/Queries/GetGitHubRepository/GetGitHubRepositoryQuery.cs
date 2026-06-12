using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Responses;

namespace Opzenix.Modules.Repositories.Application.Queries.GetGitHubRepository;

public sealed record GetGitHubRepositoryQuery(
    string Owner,
    string Repository)
    : IRequest<GitHubRepositoryResponse?>;