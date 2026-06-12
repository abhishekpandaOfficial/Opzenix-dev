using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Application.Services;

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

        review.MarkStarted();

        var filesAnalyzed = files.Count;

        var linesAnalyzed =
            files.Sum(
                x => x.Patch?.Split('\n').Length ?? 0);

        var findingsCount = 0;

        foreach (var file in files)
        {
            var findings =
                _reviewFindingService.Analyze(
                    review.Id,
                    file.FileName,
                    file.Patch);

            findingsCount += findings.Count;

            foreach (var finding in findings)
            {
                _reviewsDbContext.ReviewFindings.Add(
                    finding);
            }
        }

        review.SetMetrics(
            filesAnalyzed,
            linesAnalyzed,
            findingsCount);

        review.SetSummary(
            $"Review completed. {findingsCount} findings detected.");

        review.MarkCompleted();

        await _reviewsDbContext.SaveChangesAsync(
            cancellationToken);
    }
}