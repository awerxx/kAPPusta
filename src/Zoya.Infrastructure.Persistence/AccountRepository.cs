using Avvr.Kappusta.Zoya.Application;
using Avvr.Kappusta.Zoya.Core.Entities;

namespace Avvr.Kappusta.Zoya.Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly IReadOnlyCollection<Account> _accounts =
        Enumerable.Range(1, 10).Select(i => Account.Create($"Account {i}")).ToList().AsReadOnly();

    public Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default)
        => Task.FromResult(_accounts);
}