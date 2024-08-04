using System.Collections.Concurrent;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Core.Entities;

namespace Avvr.Kappusta.Zoya.Infrastructure.Persistence;

public class DummyAccountRepository : IAccountRepository
{
    private readonly ConcurrentDictionary<int, Account> _accounts = new()
    {
        [1] = Account.Create("Account 1"),
        [2] = Account.Create("Account 2"),
        [3] = Account.Create("Account 3"),
        [4] = Account.Create("Account 4"),
        [5] = Account.Create("Account 5"),
    };

    public async Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);

        return _accounts.Select(a => a.Value).ToList().AsReadOnly();
    }
}