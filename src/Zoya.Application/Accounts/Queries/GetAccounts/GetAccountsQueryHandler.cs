using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;

public sealed class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, AccountListResponse>
{
    private readonly IAccountRepository               _accountRepository;
    private readonly ILogger<GetAccountsQueryHandler> _logger;

    public GetAccountsQueryHandler(IAccountRepository accountRepository, ILogger<GetAccountsQueryHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger            = logger;
    }

    public async Task<AccountListResponse> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, "Getting all account list (no user yet)");
        var accounts = await _accountRepository.GetAccountsAsync(cancellationToken);

        var response = accounts.Select(account => account.Adapt<AccountResponse>()).ToList();

        return new AccountListResponse(response);
    }
}