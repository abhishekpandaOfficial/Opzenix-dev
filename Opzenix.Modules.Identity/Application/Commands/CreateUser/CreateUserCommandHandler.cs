using MediatR;
using Opzenix.Modules.Identity.Application.Interfaces;
using Opzenix.Modules.Identity.Contracts.Responses;
using Opzenix.Modules.Identity.Domain.Entities;

namespace Opzenix.Modules.Identity.Application.Commands.CreateUser;

public sealed class CreateUserCommandHandler
    : IRequestHandler<
        CreateUserCommand,
        CreateUserResponse>
{
    private readonly IIdentityDbContext _dbContext;

    public CreateUserCommandHandler(
        IIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateUserResponse> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        var user =
            new User(
                request.Email,
                request.DisplayName);

        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return new CreateUserResponse(
            user.Id,
            user.Email,
            user.DisplayName);
    }
}