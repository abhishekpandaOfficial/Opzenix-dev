using MediatR;
using Opzenix.Modules.Identity.Application.Interfaces;
using Opzenix.Modules.Identity.Contracts.Responses;
using Opzenix.Modules.Identity.Domain.Entities;

namespace Opzenix.Modules.Identity.Application.Commands.CreateOrganization;

public sealed class CreateOrganizationCommandHandler
    : IRequestHandler<
        CreateOrganizationCommand,
        CreateOrganizationResponse>
{
    private readonly IIdentityDbContext _dbContext;

    public CreateOrganizationCommandHandler(
        IIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateOrganizationResponse> Handle(
        CreateOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        var organization =
            new Organization(
                request.Name,
                request.Slug);

        _dbContext.Organizations.Add(
            organization);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return new CreateOrganizationResponse(
            organization.Id,
            organization.Name,
            organization.Slug);
    }
}