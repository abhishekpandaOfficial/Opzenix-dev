using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetFindingsAnalytics;

public sealed record GetFindingsAnalyticsQuery
    : IRequest<FindingsAnalyticsResponse>;