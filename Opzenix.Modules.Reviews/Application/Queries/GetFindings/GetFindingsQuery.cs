using MediatR;
using Opzenix.Modules.Reviews.Contracts.Responses.Findings;

namespace Opzenix.Modules.Reviews.Application.Queries.GetFindings;

public sealed record GetFindingsQuery(
    string? Severity = null,
    string? Category = null)
    : IRequest<List<ReviewFindingResponse>>;