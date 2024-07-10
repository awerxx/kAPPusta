using Avvr.Kappusta.Zoya.Core.Entities;

namespace Avvr.Kappusta.Zoya.Core;

public interface IAccountRepository
{
    Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default);
    Task<Account> CreateAccountAsync(Account account, CancellationToken cancellationToken = default);
    Task DeleteAccountAsync(AccountId accountId, CancellationToken cancellationToken = default);
    Task<Account> UpdateAccountAsync(Account account, CancellationToken cancellationToken = default);
}