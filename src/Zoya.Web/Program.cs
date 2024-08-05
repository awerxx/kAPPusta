using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Avvr.Kappusta.Zoya.Web.Data;
using Avvr.Kappusta.Zoya.Web.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder();
    builder.AddSerilog();
    builder.Configuration.SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json", optional: false)
           .AddJsonFile("appsettings.Development.json", optional: true)
           .AddEnvironmentVariables()
           .Build();
    builder.Services.AddApplication();
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddScoped<AccountService>();
    builder.Services.AddScoped<IAccountRepository, DummyAccountRepository>();

    builder.Services.AddVersionedApi();
    builder.Services.ConfigureCors();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseVersionedApi();

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Zoya host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}