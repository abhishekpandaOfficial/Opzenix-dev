using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Application.Services;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Application.Commands.GenerateReview;

public sealed class GenerateReviewCommandHandler
    : IRequestHandler<GenerateReviewCommand>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    private readonly RepositoryDbContext _repositoryDbContext;

    private readonly ReviewFindingService _reviewFindingService;

    public GenerateReviewCommandHandler(
        IReviewsDbContext reviewsDbContext,
        RepositoryDbContext repositoryDbContext,
        ReviewFindingService reviewFindingService)
    {
        _reviewsDbContext = reviewsDbContext;
        _repositoryDbContext = repositoryDbContext;
        _reviewFindingService = reviewFindingService;
    }

    public async Task Handle(
        GenerateReviewCommand request,
        CancellationToken cancellationToken)
    {
        var review =
            await _reviewsDbContext.Reviews
                .FirstAsync(
                    x => x.Id == request.ReviewId,
                    cancellationToken);

        var files =
            await _repositoryDbContext.PullRequestFiles
                .Where(
                    x => x.PullRequestId == review.PullRequestId)
                .ToListAsync(
                    cancellationToken);

        foreach (var file in files)
        {
            var findings =
                _reviewFindingService.Analyze(
                    review.Id,
                    file.FileName,
                    file.Patch);

            foreach (var finding in findings)
            {
                _reviewsDbContext.ReviewFindings.Add(
                    finding);
            }
        }
        var findingsCount =
            await _reviewsDbContext.ReviewFindings
                .CountAsync(
                    x => x.ReviewId == review.Id,
                    cancellationToken);
        Console.WriteLine(
            $"Files Loaded: {files.Count}");
        Console.WriteLine(
            $"ReviewId: {review.Id}");

        Console.WriteLine(
            $"PullRequestId: {review.PullRequestId}");

        Console.WriteLine(
            $"Files Loaded: {files.Count}");
        review.SetSummary(
            $"Review completed. {findingsCount} findings detected.");

        review.MarkCompleted();

        await _reviewsDbContext.SaveChangesAsync(
            cancellationToken);
    }
}