using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Avvr.Kappusta.Zoya.Web.Data;
using Avvr.Kappusta.Zoya.Web.DependencyInjection;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder();
    builder.AddSerilog();
    builder.Services.AddApplication();
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddScoped<AccountService>();
    builder.Services.AddScoped<IAccountRepository, DummyAccountRepository>();

    builder.Services.AddVersionedApi();
    builder.Services.AddCors(
        options => options.AddPolicy(
            "CorsPolicy",
            policyBuilder =>
            {
                policyBuilder.AllowAnyMethod()
                             .AllowAnyHeader()
                             .WithOrigins("http://localhost:5000", "https://localhost:5001")
                             .AllowCredentials();
            }));

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseVersionedApi();

    app.UseHttpsRedirection();

    app.UseStaticFiles();

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