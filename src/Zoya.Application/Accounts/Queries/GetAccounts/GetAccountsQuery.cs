using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using MediatR;

namespace Avvr.Kappusta.Zoya.Application.Accounts.Queries.GetAccounts;

public readonly record struct GetAccountsQuery() : IRequest<AccountListResponse>;