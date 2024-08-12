using Serilog.Context;

namespace Avvr.Kappusta.Zoya.Api.Middleware;

public class RequestLogContextMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLogContextMiddleware(RequestDelegate next) => _next = next;

    public Task InvokeAsync(HttpContext context)
    {
        using (LogContext.PushProperty("RequestLogId", context.TraceIdentifier))
        {
            return _next(context);
        }
    }
}