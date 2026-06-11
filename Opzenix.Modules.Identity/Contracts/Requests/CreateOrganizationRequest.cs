namespace Opzenix.Modules.Identity.Contracts.Requests;

public sealed record CreateOrganizationRequest(
    string Name,
    string Slug);