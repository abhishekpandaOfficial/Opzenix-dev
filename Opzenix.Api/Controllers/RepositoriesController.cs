using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Repositories.Application.Commands.CreateRepository;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubBranches;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubCommits;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubRepository;
using Opzenix.Modules.Repositories.Contracts.Requests;
using Opzenix.Modules.Repositories.Application.Queries.GetRepositoryById;
using Opzenix.Modules.Repositories.Application.Queries.GetRepositoriesByOrganization;

namespace Opzenix.Api.Controllers;

[ApiController]
[Route("api/repositories")]
public sealed class RepositoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RepositoriesController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateRepositoryRequest request,
        CancellationToken cancellationToken)
    {
        var command =
            new CreateRepositoryCommand(
                request.OrganizationId,
                request.Name,
                request.Url,
                request.Provider);

        var result =
            await _mediator.Send(
                command,
                cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetRepositoryByIdQuery(id),
                cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpGet("organization/{organizationId:guid}")]
    public async Task<IActionResult> GetByOrganization(
        Guid organizationId,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetRepositoriesByOrganizationQuery(
                    organizationId),
                cancellationToken);

        return Ok(result);
    }
    [HttpGet("github/{owner}/{repository}")]
    public async Task<IActionResult> GetGitHubRepository(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetGitHubRepositoryQuery(
                    owner,
                    repository),
                cancellationToken);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    [HttpGet("github/{owner}/{repository}/branches")]
    public async Task<IActionResult> GetBranches(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetGitHubBranchesQuery(
                    owner,
                    repository),
                cancellationToken);

        return Ok(result);
    }
    [HttpGet("github/{owner}/{repository}/commits/{branch}")]
    public async Task<IActionResult> GetCommits(
        string owner,
        string repository,
        string branch,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetGitHubCommitsQuery(
                    owner,
                    repository,
                    branch),
                cancellationToken);

        return Ok(result);
    }
}