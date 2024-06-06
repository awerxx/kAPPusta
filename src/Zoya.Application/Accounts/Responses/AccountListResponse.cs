namespace Avvr.Kappusta.Zoya.Application.Accounts.Responses;

public readonly record struct AccountListResponse(IReadOnlyCollection<AccountResponse> Accounts);