using System.Collections.Concurrent;
using Avvr.Kappusta.Kappusta.Common.Extensions;
using Avvr.Kappusta.Zoya.Domain;
using Avvr.Kappusta.Zoya.Domain.Entities;

namespace Avvr.Kappusta.Zoya.Infrastructure.Persistence;

public class DummyAccountRepository : IAccountRepository
{
    private readonly ConcurrentDictionary<int, Account> _accounts = new()
    {
        [1] = Account.Create("Account 1", Currency.Pln),
        [2] = Account.Create("Account 2", Currency.Eur),
        [3] = Account.Create("Account 3", Currency.Eur),
        [4] = Account.Create("Account 4", Currency.Usd),
        [5] = Account.Create("Account 5", Currency.Pln)
    };

    public async Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(millisecondsDelay: 100, cancellationToken);

        return _accounts.Select(a => a.Value).ReadOnly();
    }
}