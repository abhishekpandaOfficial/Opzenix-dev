using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Application.Commands.SyncBranches;

public sealed class SyncBranchesCommandHandler
    : IRequestHandler<SyncBranchesCommand>
{
    private readonly GitHubClient _gitHubClient;

    private readonly IRepositoryDbContext _dbContext;

    public SyncBranchesCommandHandler(
        GitHubClient gitHubClient,
        IRepositoryDbContext dbContext)
    {
        _gitHubClient = gitHubClient;
        _dbContext = dbContext;
    }

    public async Task Handle(
        SyncBranchesCommand request,
        CancellationToken cancellationToken)
    {
        var branches =
            await _gitHubClient.GetBranchesAsync(
                request.Owner,
                request.Repository,
                cancellationToken);

        if (branches is null)
        {
            return;
        }

        var existingBranches =
            await _dbContext.Branches
                .Where(x =>
                    x.RepositoryId ==
                    request.RepositoryId)
                .Select(x => x.Name)
                .ToHashSetAsync(
                    cancellationToken);

        foreach (var branch in branches)
        {
            if (existingBranches.Contains(
                    branch.Name))
            {
                continue;
            }

            _dbContext.Branches.Add(
                new Branch(
                    request.RepositoryId,
                    branch.Name,
                    branch.Name == "main"));
        }

        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}