using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetDashboardActivity;

public sealed record GetDashboardActivityQuery
    : IRequest<List<DashboardActivityResponse>>;