using Avvr.Kappusta.Zoya.Api.Middleware;

namespace Avvr.Kappusta.Zoya.Api.DependencyInjection;

internal static class Middleware
{
    public static void AddMiddleware(this WebApplication app)
        => app.UseMiddleware<RequestLogContextMiddleware>().UseMiddleware<ErrorHandlingMiddleware>();
}