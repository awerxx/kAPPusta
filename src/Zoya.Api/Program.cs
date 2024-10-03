using Avvr.Kappusta.Zoya.Api.DependencyInjection;
using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Domain;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog();
    builder.Configuration.SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: false)
           .AddJsonFile("appsettings.Development.json", optional: true)
           .AddEnvironmentVariables()
           .Build();
    builder.Services.AddApplication();

    builder.Services.AddScoped<IAccountRepository, DummyAccountRepository>();
    builder.Services.AddVersionedApi();
    builder.Services.ConfigureCors();

    var app = builder.Build();

    app.AddMiddleware();
    app.UseVersionedApi();

    app.UseHttpsRedirection();
    app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
    app.UseSerilog();

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Zoya API terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}