using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Web.DependencyInjection;

internal static class Endpoints
{
    public static void MapEndpoints(this WebApplication app) => DefineAccountEndpoints(app);

    private static void DefineAccountEndpoints(WebApplication app)
        => app.MapGet("api/accounts", GetAccounts).WithDescription("Get all user accounts");

    private static async Task<AccountListResponse> GetAccounts(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result.Value;
    }
}