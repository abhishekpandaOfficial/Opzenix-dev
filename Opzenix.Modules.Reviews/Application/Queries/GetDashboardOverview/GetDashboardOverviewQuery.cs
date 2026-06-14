using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetDashboardOverview;

public sealed record GetDashboardOverviewQuery
    : IRequest<DashboardOverviewResponse>;