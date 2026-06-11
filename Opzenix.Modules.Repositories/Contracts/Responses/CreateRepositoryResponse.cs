namespace Opzenix.Modules.Repositories.Contracts.Responses;

public sealed record CreateRepositoryResponse(
    Guid Id,
    Guid OrganizationId,
    string Name,
    string Url,
    string Provider);