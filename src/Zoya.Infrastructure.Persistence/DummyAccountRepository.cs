using System.Collections.Concurrent;
using Avvr.Kappusta.Zoya.Core;
using Avvr.Kappusta.Zoya.Core.Entities;

namespace Avvr.Kappusta.Zoya.Infrastructure.Persistence;

public class DummyAccountRepository : IAccountRepository
{
    private readonly ConcurrentDictionary<int, Account> _accounts = new()
    {
        [1] = Account.Create(1, "Account 1"),
        [2] = Account.Create(2, "Account 2"),
        [3] = Account.Create(3, "Account 3"),
        [4] = Account.Create(4, "Account 4"),
        [5] = Account.Create(5, "Account 5"),
    };

    public async Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(100, cancellationToken);

        return _accounts.Select(a => a.Value).ToList().AsReadOnly();
    }

    public Task<Account> CreateAccountAsync(Account account, CancellationToken cancellationToken = default)
    {
        _ = _accounts.TryAdd(account.Id.Value, account);

        return Task.FromResult(account);
    }

    public Task DeleteAccountAsync(AccountId accountId, CancellationToken cancellationToken = default)
    {
        _ = _accounts.TryRemove(accountId.Value, out _);

        return Task.CompletedTask;
    }

    public Task<Account> UpdateAccountAsync(Account account, CancellationToken cancellationToken = default)
    {
        _ = _accounts.TryUpdate(key: account.Id.Value, account, account);

        return Task.FromResult(account);
    }
}