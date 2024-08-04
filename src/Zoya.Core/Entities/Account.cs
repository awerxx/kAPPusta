namespace Avvr.Kappusta.Zoya.Core.Entities;

public sealed class Account
{
    private Account(AccountId id, string name)
    {
        Id   = id;
        Name = name;
    }

    private Account(string name)
        : this(new AccountId(new Guid()), name) { }

    public AccountId Id { get; }
    public string Name { get; }

    public static Account Create(string name) => new(name);
}