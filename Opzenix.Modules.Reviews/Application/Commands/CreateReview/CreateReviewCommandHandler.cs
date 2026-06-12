using MediatR;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Domain.Entities;

namespace Opzenix.Modules.Reviews.Application.Commands.CreateReview;

public sealed class CreateReviewCommandHandler
    : IRequestHandler<CreateReviewCommand, Guid>
{
    private readonly IReviewsDbContext _dbContext;

    public CreateReviewCommandHandler(
        IReviewsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(
        CreateReviewCommand request,
        CancellationToken cancellationToken)
    {
        var review =
            new Review(
                request.PullRequestId);

        _dbContext.Reviews.Add(
            review);

        await _dbContext.SaveChangesAsync(
            cancellationToken);

        return review.Id;
    }
}