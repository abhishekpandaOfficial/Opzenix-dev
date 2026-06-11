namespace Opzenix.Modules.Identity.Contracts.Responses;

public sealed record AddUserToOrganizationResponse(
    Guid MembershipId,
    Guid OrganizationId,
    Guid UserId);