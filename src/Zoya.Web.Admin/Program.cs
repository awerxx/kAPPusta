using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Domain;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Avvr.Kappusta.Zoya.Web.Admin.Data;
using Avvr.Kappusta.Zoya.Web.Admin.DependencyInjection;
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

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Zoya Web Admin terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}