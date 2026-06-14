using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetTopRepositories;

public sealed class GetTopRepositoriesQueryHandler
    : IRequestHandler<
        GetTopRepositoriesQuery,
        List<TopRepositoryResponse>>
{
    private readonly RepositoryDbContext _repositoryDbContext;

    public GetTopRepositoriesQueryHandler(
        RepositoryDbContext repositoryDbContext)
    {
        _repositoryDbContext = repositoryDbContext;
    }

    public async Task<List<TopRepositoryResponse>> Handle(
        GetTopRepositoriesQuery request,
        CancellationToken cancellationToken)
    {
        var repositories =
            await _repositoryDbContext.Repositories
                .AsNoTracking()
                .ToListAsync(
                    cancellationToken);

        var result =
            new List<TopRepositoryResponse>();

        foreach (var repository in repositories)
        {
            var pullRequests =
                await _repositoryDbContext.PullRequests
                    .CountAsync(
                        x => x.RepositoryId == repository.Id,
                        cancellationToken);

            var branches =
                await _repositoryDbContext.Branches
                    .CountAsync(
                        x => x.RepositoryId == repository.Id,
                        cancellationToken);

            result.Add(
                new TopRepositoryResponse
                {
                    RepositoryId = repository.Id,
                    Name = repository.Name,
                    PullRequests = pullRequests,
                    Branches = branches,
                    Commits = 0
                });
        }

        return result
            .OrderByDescending(
                x => x.PullRequests)
            .Take(10)
            .ToList();
    }
}