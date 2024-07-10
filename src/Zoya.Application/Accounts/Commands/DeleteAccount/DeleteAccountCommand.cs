using FluentResults;
using MediatR;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Commands.DeleteAccount;

public readonly record struct DeleteAccountCommand(int Id) : IRequest<Result>;