using Asp.Versioning;
using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Api.DependencyInjection;

internal static class Endpoints
{
    private static readonly ApiVersion _apiVersion = new(1);

    public static IServiceCollection AddVersionedApi(this IServiceCollection services)
    {
        services.AddApiVersioning(
                    options =>
                    {
                        options.DefaultApiVersion                   = _apiVersion;
                        options.ReportApiVersions                   = true;
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.ApiVersionReader = ApiVersionReader.Combine(
                            new UrlSegmentApiVersionReader(),
                            new HeaderApiVersionReader("X-Api-Version"));
                    })
                .AddApiExplorer(
                    options =>
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

        MapAccountEndpoints(group);
    }

    private static void UseSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                options.SwaggerEndpoint($"/swagger/v{_apiVersion}/swagger.json", $"Zoya {_apiVersion}");
                options.RoutePrefix = "swagger";
            });
    }

    private static void MapAccountEndpoints(RouteGroupBuilder app)
        => app.MapGet("accounts", GetAccounts)
              .WithDescription("Get all user accounts")
              .WithName("GetAccounts")
              .WithOpenApi();

    private static async Task<AccountListResponse> GetAccounts(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result.Value;
    }
}