using Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;
using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Core.Entities;
using FluentResults;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.UpdateAccount;

public sealed class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result<AccountResponse>>
{
    private readonly IAccountRepository               _accountRepository;
    private readonly ILogger<GetAccountsQueryHandler> _logger;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository, ILogger<GetAccountsQueryHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger            = logger;
    }

    public async Task<Result<AccountResponse>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"Updating account {request.Name}");

        var account        = request.Adapt<Account>();
        var updatedAccount = await _accountRepository.UpdateAccountAsync(account, cancellationToken);

        var response = updatedAccount .Adapt<AccountResponse>();

        return response;
    }
}