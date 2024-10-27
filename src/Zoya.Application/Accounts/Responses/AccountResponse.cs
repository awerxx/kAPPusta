namespace Avvr.Kappusta.Zoya.Application.Accounts.Responses;

public readonly record struct AccountResponse(
    string DisplayName,
    decimal Balance,
    string CurrencySymbol,
    DateTime CreatedOn);