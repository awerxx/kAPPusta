using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Api.Endpoints;

internal static class AccountsHandler
{
    public static void MapAccountEndpoints(this RouteGroupBuilder routes)
        => routes.MapGet("accounts", GetAccounts)
                 .WithDescription("Get all user's accounts")
                 .WithName("GetAccounts");

    private static async Task<AccountListResponse> GetAccounts(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result.Value;
    }
}