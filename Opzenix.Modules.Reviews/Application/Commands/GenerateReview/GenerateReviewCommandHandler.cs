using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Interfaces;

using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Models;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Application.Commands.GenerateReview;

public sealed class GenerateReviewCommandHandler
    : IRequestHandler<GenerateReviewCommand>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    private readonly RepositoryDbContext _repositoryDbContext;
    private readonly IAiProviderFactory _aiProviderFactory;
    
    public GenerateReviewCommandHandler(
        IReviewsDbContext reviewsDbContext,
        RepositoryDbContext repositoryDbContext,
        IAiProviderFactory aiProviderFactory)
    {
        _reviewsDbContext = reviewsDbContext;
        _repositoryDbContext = repositoryDbContext;
        _aiProviderFactory = aiProviderFactory;
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
        var provider =
            _aiProviderFactory.GetProvider(
                "RuleBased");

        foreach (var file in files)
        {
            var response =
                await provider.ReviewAsync(
                    new AiReviewRequest
                    {
                        ReviewId = review.Id,
                        FileName = file.FileName,
                        Content = file.Patch
                    },
                    cancellationToken);

            findingsCount += response.Findings.Count;

            foreach (var finding in response.Findings)
            {
                _reviewsDbContext.ReviewFindings.Add(
                    new ReviewFinding(
                        review.Id,
                        finding.FileName,
                        finding.Severity,
                        finding.Category,
                        finding.Message,
                        finding.Recommendation));
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