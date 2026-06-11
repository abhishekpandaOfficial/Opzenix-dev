using MediatR;
using Opzenix.Modules.Identity.Application.Interfaces;
using Opzenix.Modules.Identity.Contracts.Responses;
using Opzenix.Modules.Identity.Domain.Entities;

namespace Opzenix.Modules.Identity.Application.Commands.AddUserToOrganization;

public sealed class AddUserToOrganizationCommandHandler
    : IRequestHandler<
        AddUserToOrganizationCommand,
        AddUserToOrganizationResponse>
{
    private readonly IIdentityDbContext _dbContext;

    public AddUserToOrganizationCommandHandler(
        IIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AddUserToOrganizationResponse> Handle(
        AddUserToOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var membership =
            new OrganizationMembership(
                request.OrganizationId,
                request.UserId);

        _dbContext.Memberships.Add(
            membership);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return new AddUserToOrganizationResponse(
            membership.Id,
            membership.OrganizationId,
            membership.UserId);
    }
}