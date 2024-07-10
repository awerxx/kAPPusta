namespace Avvr.Kappusta.Zoya.Core.Entities;

public sealed class Account
{
    private Account(int id, string name)
    {
        Id   = new AccountId(id);
        Name = new AccountName(name);
    }

    private Account(string name)
        : this(Random.Shared.Next(1, 100), name) { }

    public AccountId Id { get; }
    public AccountName Name { get; }

    public static Account Create(int id, string name) => new(id, name);
    public static Account Create(string name) => new(name);
}