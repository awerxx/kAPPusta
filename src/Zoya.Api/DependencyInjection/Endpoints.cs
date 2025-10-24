using Asp.Versioning;
using Avvr.Kappusta.Zoya.Api.Endpoints;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

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

        services.AddOpenApi(options => options.AddDocumentTransformer((document, context, cancellationToken) =>
        {
            document.Info.Version     = _apiVersion.ToString();
            document.Info.Title       = "Zoya API";
            document.Info.Description = "This API hmm...";
            document.Info.Contact = new OpenApiContact
            {
                Name = "Me",
            };
            document.Info.License = new OpenApiLicense
            {
                Name = "MIT License",
                Url  = new Uri($"https://opensource.org/licenses/MIT", UriKind.Absolute)
            };
            return Task.CompletedTask;
        }));

        return services;
    }

    public static void UseVersionedApi(this WebApplication app)
    {
        var apiVersionSet = app.NewApiVersionSet().HasApiVersion(_apiVersion).ReportApiVersions().Build();
        var group         = app.MapGroup("v{version:apiVersion}").WithApiVersionSet(apiVersionSet);
        if (app.Environment.IsDevelopment())
            UseApiDocumentation(app);

        group.MapAccountEndpoints();
    }

    private static void UseApiDocumentation(WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference(options =>
        {
            options.WithTheme(ScalarTheme.Kepler);

            options.HideDarkModeToggle = false;
            options.HideClientButton   = false;
        });
    }
}