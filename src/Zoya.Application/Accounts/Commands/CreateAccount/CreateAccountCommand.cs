using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using FluentResults;
using MediatR;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.CreateAccount;

public readonly record struct CreateAccountCommand(string Name) : IRequest<Result<AccountResponse>>;