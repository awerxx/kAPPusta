using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Core.Entities;
using FluentResults;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.CreateAccount;

public sealed class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<AccountResponse>>
{
    private readonly IAccountRepository                   _accountRepository;
    private readonly ILogger<CreateAccountCommandHandler> _logger;

    public CreateAccountCommandHandler(
        IAccountRepository accountRepository,
        ILogger<CreateAccountCommandHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger            = logger;
    }

    public async Task<Result<AccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"Creating new account {request.Name}");

        var account    = Account.Create(request.Name);
        var newAccount = await _accountRepository.CreateAccountAsync(account, cancellationToken);

        var response = newAccount.Adapt<AccountResponse>();

        return response;
    }
}