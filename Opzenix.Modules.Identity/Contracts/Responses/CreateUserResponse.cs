namespace Opzenix.Modules.Identity.Contracts.Responses;

public sealed record CreateUserResponse(
    Guid Id,
    string Email,
    string DisplayName);