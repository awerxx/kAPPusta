using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;

namespace Avvr.Kappusta.Zoya.Web.Endpoints;

public class AccountEndpoints
{
    public static void DefineEndpoints(WebApplication app)
    {
        app.MapGet("api/accounts", GetAccounts);
    }

    private static async Task<AccountListResponse> GetAccounts(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result;
    }
}
