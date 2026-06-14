using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Analytics;

namespace Opzenix.Modules.Reviews.Application.Queries.GetProviderAnalytics;

public sealed record GetProviderAnalyticsQuery
    : IRequest<List<ProviderAnalyticsResponse>>;