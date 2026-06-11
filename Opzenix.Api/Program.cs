using Opzenix.BuildingBlocks;
using Opzenix.Modules.Identity.Infrastructure;
using Scalar.AspNetCore;
using Opzenix.Modules.Repositories.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddBuildingBlocks();

builder.Services.AddIdentityModule(
    builder.Configuration);

builder.Services.AddRepositoriesModule(
    builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();