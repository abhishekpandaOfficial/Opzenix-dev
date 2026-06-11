namespace Opzenix.Modules.Identity.Contracts.Requests;

public sealed record CreateUserRequest(
    string Email,
    string DisplayName);