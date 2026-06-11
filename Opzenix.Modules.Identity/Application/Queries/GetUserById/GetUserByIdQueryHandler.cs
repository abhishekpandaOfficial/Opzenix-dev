using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Identity.Application.Interfaces;
using Opzenix.Modules.Identity.Contracts.Responses;

namespace Opzenix.Modules.Identity.Application.Queries.GetUserById;

public sealed class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, UserResponse?>
{
    private readonly IIdentityDbContext _dbContext;

    public GetUserByIdQueryHandler(
        IIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserResponse?> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var user =
            await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    x => x.Id == request.UserId,
                    cancellationToken);

        if (user is null)
        {
            return null;
        }

        return new UserResponse(
            user.Id,
            user.Email,
            user.DisplayName,
            user.IsActive);
    }
}