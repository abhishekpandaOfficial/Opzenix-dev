using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opzenix.Modules.Reviews.Application.Interfaces;
using Opzenix.Modules.Reviews.Infrastructure.Persistence;
using MediatR;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using Opzenix.Modules.Reviews.Application.Commands.CreateReview;
using Opzenix.Modules.Reviews.Application.Services;

namespace Opzenix.Modules.Reviews.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddReviewsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString(
                "opzenix");

        services.AddDbContext<ReviewsDbContext>(
            options =>
            {
                options.UseNpgsql(
                    connectionString);
            });

        services.AddScoped<
            IReviewsDbContext,
            ReviewsDbContext>();
        services.AddScoped<
            ReviewFindingService>();
        services.AddScoped<
            RepositoryDbContext>();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<
                CreateReviewCommandHandler>();
        });

        return services;
    }
}