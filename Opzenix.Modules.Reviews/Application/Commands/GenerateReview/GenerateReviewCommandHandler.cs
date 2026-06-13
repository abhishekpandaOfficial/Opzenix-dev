using MediatR;
using Microsoft.EntityFrameworkCore;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.BuildingBlocks.AI.Enums;


using Opzenix.BuildingBlocks.AI.Abstractions;
using Opzenix.BuildingBlocks.AI.Models;
using Opzenix.Modules.Reviews.Domain.Entities;
using Microsoft.Extensions.Options;
using Opzenix.BuildingBlocks.AI.Configuration;
using Opzenix.Modules.Reviews.Application.Mappers;

namespace Opzenix.Modules.Reviews.Application.Commands.GenerateReview;

public sealed class GenerateReviewCommandHandler
    : IRequestHandler<GenerateReviewCommand>
{
    private readonly IReviewsDbContext _reviewsDbContext;

    private readonly RepositoryDbContext _repositoryDbContext;
    private readonly IAiProviderFactory _aiProviderFactory;
    private readonly AiOptions _aiOptions;
    
    public GenerateReviewCommandHandler(
        IReviewsDbContext reviewsDbContext,
        RepositoryDbContext repositoryDbContext,
        IAiProviderFactory aiProviderFactory,
        IOptions<AiOptions> aiOptions)
    {
        _reviewsDbContext = reviewsDbContext;
        _repositoryDbContext = repositoryDbContext;
        _aiProviderFactory = aiProviderFactory;
        _aiOptions = aiOptions.Value;
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
                _aiOptions.DefaultProvider);
        
        review.SetAiMetadata(
            provider.Name,
            provider.Model);

        foreach (var file in files)
        {
            var response =
                await provider.ReviewAsync(
                    new AiReviewRequest
                    {
                        ReviewId = review.Id,
                        FileName = file.FileName,
                        Content = file.Patch,
                        ReviewType =
                            AiReviewTypeMapper.Map(
                                review.ReviewType)
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