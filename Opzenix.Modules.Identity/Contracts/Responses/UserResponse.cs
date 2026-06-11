namespace Opzenix.Modules.Identity.Contracts.Responses;

public sealed record UserResponse(
    Guid Id,
    string Email,
    string DisplayName,
    bool IsActive);