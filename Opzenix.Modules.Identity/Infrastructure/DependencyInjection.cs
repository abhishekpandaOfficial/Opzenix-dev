using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Opzenix.Modules.Identity.Infrastructure.Persistence;
using FluentValidation;
using Opzenix.Modules.Identity.Application.Commands.CreateOrganization;
using Opzenix.Modules.Identity.Application.Interfaces;
using Opzenix.Modules.Identity.Application.Validators;
using MediatR;
using Opzenix.Modules.Identity.Application.Behaviors;

namespace Opzenix.Modules.Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("opzenix");
        Console.WriteLine(
            $"Connection String = {connectionString}");

        services.AddDbContext<IdentityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<
            IIdentityDbContext,
            IdentityDbContext>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateOrganizationCommandHandler>();
        });
        
        services.AddValidatorsFromAssemblyContaining<CreateOrganizationValidator>();
        
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));
        
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(LoggingBehavior<,>));
        
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ExceptionBehavior<,>));
        return services;
    }
}

//Pipeline Execution Order

 //Requests will flow like this:
// HTTP Request
//     ↓
// Controller
//     ↓
// ValidationBehavior
//     ↓
// LoggingBehavior
//     ↓
// ExceptionBehavior
//     ↓
// Handler
//     ↓
// EF Core
//     ↓
// PostgreSQL