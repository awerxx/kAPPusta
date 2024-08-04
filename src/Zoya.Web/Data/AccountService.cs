using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;

namespace Avvr.Kappusta.Zoya.Web.Data;

public class AccountService
{
    private readonly IMediator _mediator;

    public AccountService(IMediator mediator) => _mediator = mediator;

    public async Task<AccountListResponse> GetAccountsAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request: new GetAccountsQuery(), cancellationToken);

        return result.Value;
    }
}