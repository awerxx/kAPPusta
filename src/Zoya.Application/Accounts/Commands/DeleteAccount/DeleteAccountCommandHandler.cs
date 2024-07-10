using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Core.Entities;
using FluentResults;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.DeleteAccount;

public sealed class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
{
    private readonly IAccountRepository                   _accountRepository;
    private readonly ILogger<DeleteAccountCommandHandler> _logger;

    public DeleteAccountCommandHandler(
        IAccountRepository accountRepository,
        ILogger<DeleteAccountCommandHandler> logger)
    {
        _accountRepository = accountRepository;
        _logger            = logger;
    }

    public async Task<Result> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, $"Deleting account {request.Id}");

        var accountId = new AccountId(request.Id);
        await _accountRepository.DeleteAccountAsync(accountId, cancellationToken);

        return Result.Ok();
    }
}