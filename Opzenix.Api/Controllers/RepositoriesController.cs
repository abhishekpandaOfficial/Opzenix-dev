using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opzenix.Modules.Repositories.Application.Commands.CreateRepository;
using Opzenix.Modules.Repositories.Application.Commands.SyncBranches;
using Opzenix.Modules.Repositories.Application.Commands.SyncCommits;
using Opzenix.Modules.Repositories.Application.Commands.SyncPullRequestFiles;
using Opzenix.Modules.Repositories.Application.Commands.SyncPullRequests;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubBranches;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubCommits;
using Opzenix.Modules.Repositories.Application.Queries.GetGitHubPullRequests;
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
    [HttpGet("github/{owner}/{repository}/pullrequests")]
    public async Task<IActionResult> GetPullRequests(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        var result =
            await _mediator.Send(
                new GetGitHubPullRequestsQuery(
                    owner,
                    repository),
                cancellationToken);

        return Ok(result);
    }
    [HttpPost("{repositoryId:guid}/sync-branches")]
    public async Task<IActionResult> SyncBranches(
        Guid repositoryId,
        [FromQuery] string owner,
        [FromQuery] string repository,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new SyncBranchesCommand(
                repositoryId,
                owner,
                repository),
            cancellationToken);

        return Ok();
    }
    [HttpPost("{repositoryId:guid}/branches/{branchId:guid}/sync-commits")]
    public async Task<IActionResult> SyncCommits(
        Guid repositoryId,
        Guid branchId,
        [FromQuery] string owner,
        [FromQuery] string repository,
        [FromQuery] string branch,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new SyncCommitsCommand(
                repositoryId,
                branchId,
                owner,
                repository,
                branch),
            cancellationToken);

        return Ok();
    }
    [HttpPost("{repositoryId:guid}/sync-pullrequests")]
    public async Task<IActionResult> SyncPullRequests(
        Guid repositoryId,
        [FromQuery] string owner,
        [FromQuery] string repository,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new SyncPullRequestsCommand(
                repositoryId,
                owner,
                repository),
            cancellationToken);

        return Ok();
    }
    [HttpPost(
        "pullrequests/{pullRequestId:guid}/sync-files")]
    public async Task<IActionResult> SyncPullRequestFiles(
        Guid pullRequestId,
        [FromQuery] string owner,
        [FromQuery] string repository,
        [FromQuery] int pullRequestNumber,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(
            new SyncPullRequestFilesCommand(
                pullRequestId,
                owner,
                repository,
                pullRequestNumber),
            cancellationToken);

        return Ok();
    }
}