using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Dashboard;

namespace Opzenix.Modules.Reviews.Application.Queries.GetTopRepositories;

public sealed record GetTopRepositoriesQuery
    : IRequest<List<TopRepositoryResponse>>;