namespace Avvr.Kappusta.Zoya.Core.Entities;

public class Account
{
    private Account(string name) => Name = name;

    public string Name { get; }

    public static Account Create(string name) => new(name);
}
