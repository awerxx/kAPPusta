using Serilog;

namespace Avvr.Kappusta.Zoya.Web.Admin.DependencyInjection;

internal static class Logging
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        builder.Host.UseSerilog(
            (context, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(context.Configuration);
            });
    }
}