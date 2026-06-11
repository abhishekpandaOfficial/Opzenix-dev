namespace Opzenix.Modules.Repositories.Contracts.Requests;

public sealed record CreateRepositoryRequest(
    Guid OrganizationId,
    string Name,
    string Url,
    string Provider);