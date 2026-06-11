using MediatR;
using Opzenix.Modules.Repositories.Contracts.Responses;

namespace Opzenix.Modules.Repositories.Application.Commands.CreateRepository;

public sealed record CreateRepositoryCommand(
    Guid OrganizationId,
    string Name,
    string Url,
    string Provider)
    : IRequest<CreateRepositoryResponse>;