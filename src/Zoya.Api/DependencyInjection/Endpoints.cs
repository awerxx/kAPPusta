using Asp.Versioning;
using Avvr.Kappusta.Zoya.Api.Endpoints;

namespace Avvr.Kappusta.Zoya.Api.DependencyInjection;

internal static class Endpoints
{
    private static readonly ApiVersion _apiVersion = new(1);

    public static IServiceCollection AddVersionedApi(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
                {
                    options.DefaultApiVersion                   = _apiVersion;
                    options.ReportApiVersions                   = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        apiVersionReader: new UrlSegmentApiVersionReader(),
                        new HeaderApiVersionReader("X-Api-Version"));
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat           = "'v'V";
                    options.SubstituteApiVersionInUrl = true;
                });

        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static void UseVersionedApi(this WebApplication app)
    {
        var apiVersionSet = app.NewApiVersionSet().HasApiVersion(_apiVersion).ReportApiVersions().Build();
        var group         = app.MapGroup("v{version:apiVersion}").WithApiVersionSet(apiVersionSet);
        if (app.Environment.IsDevelopment())
            UseSwagger(app);

        group.MapAccountEndpoints();
    }

    private static void UseSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(url: $"/swagger/v{_apiVersion}/swagger.json", name: $"Zoya {_apiVersion}");
            options.RoutePrefix = "swagger";
        });
    }
}