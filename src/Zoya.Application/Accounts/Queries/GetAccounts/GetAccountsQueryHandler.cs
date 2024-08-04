using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using FluentResults;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;

public sealed class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, Result<AccountListResponse>>
{
    private readonly IAccountRepository               _accountRepository;
    private readonly ILogger<GetAccountsQueryHandler> _logger;

    public GetAccountsQueryHandler(IAccountRepository accountRepository, ILogger<GetAccountsQueryHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger            = logger;
    }

    public async Task<Result<AccountListResponse>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.Log(LogLevel.Information, "Getting all accounts (no user yet)");
            var accounts = await _accountRepository.GetAccountsAsync(cancellationToken);

            var response = accounts.Select(account => account.Adapt<AccountResponse>()).ToArray();

            return Result.Ok(new AccountListResponse(response));
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error while getting account list");
            return Result.Fail("Error while getting account list. Map me.");
        }
    }
}