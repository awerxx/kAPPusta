using System.Globalization;
using Serilog;
using Serilog.Events;

namespace Avvr.Kappusta.Zoya.Web.Admin.DependencyInjection;

internal static class Logging
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration().WriteTo.Console(
                                                  restrictedToMinimumLevel: LogEventLevel.Debug,
                                                  formatProvider: CultureInfo.CurrentCulture)
                                              .CreateLogger();

        builder.Host.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(context.Configuration);
        });
    }
}