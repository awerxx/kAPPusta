using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Avvr.Kappusta.Zoya.Web.DependencyInjection;

internal static class Logging
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

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
    }
}