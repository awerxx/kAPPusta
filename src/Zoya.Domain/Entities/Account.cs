using Avvr.Kappusta.Kappusta.Common.Model;

namespace Avvr.Kappusta.Zoya.Domain.Entities;

public sealed class Account : Entity<AccountId>
{
    private Account(AccountId id, AccountName name, Currency currency)
        : base(id)
    {
        Currency  = currency;
        Balance   = new AccountBalance(currency);
        Name      = name;
        CreatedOn = DateTime.UtcNow;
    }

    private Account(string name, Currency currency)
        : this(id: new AccountId(new Guid()), name, currency) { }

    public AccountName Name { get; }

    public Currency Currency { get; }

    public DateTime CreatedOn { get; }

    public AccountBalance Balance { get; private set; }

    public static Account Create(AccountName name, Currency currency) => new(name, currency);
}