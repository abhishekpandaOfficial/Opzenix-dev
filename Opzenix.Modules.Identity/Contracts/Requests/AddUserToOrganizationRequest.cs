namespace Opzenix.Modules.Identity.Contracts.Requests;

public sealed record AddUserToOrganizationRequest(
    Guid OrganizationId,
    Guid UserId);