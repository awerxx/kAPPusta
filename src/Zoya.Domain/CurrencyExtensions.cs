namespace Avvr.Kappusta.Zoya.Domain;

public static class CurrencyExtensions
{
    public static string ToDisplayName(this Currency currency)
        => currency switch
        {
            Currency.Pln => "PLN",
            Currency.Eur => "EUR",
            Currency.Usd => "USD",
            _            => currency.ToString()
        };

    public static string ToSymbol(this Currency currency)
        => currency switch
        {
            Currency.Pln => "zł",
            Currency.Eur => "€",
            Currency.Usd => "$",
            _            => currency.ToString()
        };
}