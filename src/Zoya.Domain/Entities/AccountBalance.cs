using Avvr.Kappusta.Kappusta.Common.Model;

namespace Avvr.Kappusta.Zoya.Domain.Entities;

public sealed class AccountBalance : ValueObject
{
    private readonly Currency _currency;

    public AccountBalance(Currency currency) => _currency = currency;

    public decimal Amount { get; } = decimal.Zero;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _currency;
        yield return Amount;
    }
}