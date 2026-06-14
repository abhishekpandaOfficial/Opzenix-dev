using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetDashboardOverview;

public sealed class GetDashboardOverviewQueryHandler
    : IRequestHandler<
        GetDashboardOverviewQuery,
        DashboardOverviewResponse>
{
    private readonly RepositoryDbContext _repositoryDbContext;

    private readonly IReviewsDbContext _reviewsDbContext;

    public GetDashboardOverviewQueryHandler(
        RepositoryDbContext repositoryDbContext,
        IReviewsDbContext reviewsDbContext)
    {
        _repositoryDbContext = repositoryDbContext;
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<DashboardOverviewResponse> Handle(
        GetDashboardOverviewQuery request,
        CancellationToken cancellationToken)
    {
        var repositories =
            await _repositoryDbContext.Repositories
                .CountAsync(
                    cancellationToken);

        var pullRequests =
            await _repositoryDbContext.PullRequests
                .CountAsync(
                    cancellationToken);

        var reviews =
            await _reviewsDbContext.Reviews
                .CountAsync(
                    cancellationToken);

        var findings =
            await _reviewsDbContext.ReviewFindings
                .CountAsync(
                    cancellationToken);

        return new DashboardOverviewResponse
        {
            Repositories = repositories,
            PullRequests = pullRequests,
            Reviews = reviews,
            Findings = findings
        };
    }
}