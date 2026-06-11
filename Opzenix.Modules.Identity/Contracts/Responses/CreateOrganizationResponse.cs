namespace Opzenix.Modules.Identity.Contracts.Responses;

public sealed record CreateOrganizationResponse(
    Guid Id,
    string Name,
    string Slug);