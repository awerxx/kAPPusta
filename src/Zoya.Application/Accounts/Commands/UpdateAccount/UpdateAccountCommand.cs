using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using FluentResults;
using MediatR;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.UpdateAccount;

public readonly record struct UpdateAccountCommand(int Id, string Name) : IRequest<Result<AccountResponse>>;