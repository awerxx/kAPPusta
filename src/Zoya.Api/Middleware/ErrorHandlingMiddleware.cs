using System.Net;

namespace Avvr.Kappusta.Zoya.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate                  _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}