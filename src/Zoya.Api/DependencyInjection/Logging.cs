using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Avvr.Kappusta.Zoya.Api.DependencyInjection;

internal static class Logging
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration().CreateLogger();

        builder.Host.UseSerilog(
            (context, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
            });
    }

    public static void UseSerilog(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
    }
}