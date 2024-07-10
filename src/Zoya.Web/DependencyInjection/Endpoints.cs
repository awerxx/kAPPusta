using Avvr.Kappusta.Zoya.Application.Accounts.Commands.CreateAccount;
using Avvr.Kappusta.Zoya.Application.Accounts.Commands.DeleteAccount;
using Avvr.Kappusta.Zoya.Application.Accounts.Commands.UpdateAccount;
using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avvr.Kappusta.Zoya.Web.DependencyInjection;

internal static class Endpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        DefineAccountEndpoints(app);
    }

    private static void DefineAccountEndpoints(WebApplication app)
    {
        app.MapGet("api/accounts", GetAccounts);
        app.MapPost("api/accounts", CreateAccount);
        app.MapDelete("api/accounts/{id}", DeleteAccount);
        app.MapPatch("api/accounts/{id}", UpdateAccount);
    }

    private static async Task<AccountListResponse> GetAccounts(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result.Value;
    }

    private static async Task<AccountResponse> CreateAccount(
        [FromBody] string name,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new CreateAccountCommand(name), cancellationToken);

        return result.Value;
    }

    private static async Task DeleteAccount(
        [FromRoute] int id,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
        => await mediator.Send(request: new DeleteAccountCommand(id), cancellationToken);

    private static async Task<AccountResponse> UpdateAccount(
        [FromRoute] int id,
        [FromBody] string name,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new UpdateAccountCommand(id, name), cancellationToken);

        return result.Value;
    }
}