using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opzenix.Modules.Repositories.Application.Interfaces;
using Opzenix.Modules.Repositories.Infrastructure.Persistence;
using FluentValidation;
using Opzenix.Modules.Repositories.Application.Commands.CreateRepository;
using Opzenix.Modules.Repositories.Application.Services;
using Opzenix.Modules.Repositories.Application.Validators;
using Opzenix.Modules.Repositories.Infrastructure.GitProviders.GitHub.Clients;

namespace Opzenix.Modules.Repositories.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositoriesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("opzenix");

        services.AddDbContext<RepositoryDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<
            IRepositoryDbContext,
            RepositoryDbContext>();
    
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateRepositoryCommandHandler>();
        });

        services.AddValidatorsFromAssemblyContaining<CreateRepositoryValidator>();
        services.AddScoped<
            IRepositorySyncService,
            RepositorySyncService>();
        services.AddHttpClient<GitHubClient>(client =>
        {
            client.BaseAddress =
                new Uri("https://api.github.com/");

            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Opzenix");
        });
        return services;
    }
}