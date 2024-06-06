using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;

public sealed class GetAccountsQueryHandler(
    IAccountRepository accountRepository,
    ILogger<GetAccountsQueryHandler> logger) : IRequestHandler<GetAccountsQuery, AccountListResponse>
{
    private readonly IAccountRepository               _accountRepository = accountRepository;
    private readonly ILogger<GetAccountsQueryHandler> _logger            = logger;

    public async Task<AccountListResponse> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, "Getting all account list (no user yet)");
        var accounts = await _accountRepository.GetAccountsAsync(cancellationToken);

        var response = accounts.Select(a => new AccountResponse(a.Name)).ToList();

        return new AccountListResponse(response);
    }
}