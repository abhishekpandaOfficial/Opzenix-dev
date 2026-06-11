using MediatR;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Contracts.Responses;
using Opzenix.Modules.Repositories.Domain.Entities;

namespace Opzenix.Modules.Repositories.Application.Commands.CreateRepository;

public sealed class CreateRepositoryCommandHandler
    : IRequestHandler<
        CreateRepositoryCommand,
        CreateRepositoryResponse>
{
    private readonly IRepositoryDbContext _dbContext;

    public CreateRepositoryCommandHandler(
        IRepositoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateRepositoryResponse> Handle(
        CreateRepositoryCommand request,
        CancellationToken cancellationToken)
    {
        var repository =
            new Repository(
                request.OrganizationId,
                request.Name,
                request.Url,
                request.Provider);

        _dbContext.Repositories.Add(repository);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return new CreateRepositoryResponse(
            repository.Id,
            repository.OrganizationId,
            repository.Name,
            repository.Url,
            repository.Provider);
    }
}