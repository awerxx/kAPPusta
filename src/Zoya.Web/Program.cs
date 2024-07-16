using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Infrastructure.Persistence;
using Avvr.Kappusta.Zoya.Web.Data;
using Avvr.Kappusta.Zoya.Web.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
try
{
    Log.Information("Zoya is starting up...");
    var builder = WebApplication.CreateBuilder();

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddHttpClient<AccountService>();
    builder.Services.AddSingleton<IAccountRepository, DummyAccountRepository>();
    builder.Services.AddApplication();
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();

    var isJsonConsoleLoggingEnabled = builder.Configuration.GetValue<bool>("Logging:JsonConsoleLoggingEnabled");
    var minimumLogLevel             = builder.Configuration.GetValue<LogEventLevel>("Logging:LogLevel:Default");
    if (isJsonConsoleLoggingEnabled)
    {
        builder.Host.UseSerilog(
            (_, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.Console(new RenderedCompactJsonFormatter(), minimumLogLevel);
            });
    }
    else
    {
        builder.Host.UseSerilog(
            (_, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.Console(minimumLogLevel);
            });
    }

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

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Zoya v1");
                options.RoutePrefix = string.Empty;
            });
    }

    app.MapEndpoints();

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