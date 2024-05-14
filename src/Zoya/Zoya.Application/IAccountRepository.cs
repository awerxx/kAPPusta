using Avvr.Kappusta.Zoya.Core.Entities;

namespace Avvr.Kappusta.Zoya.Application;

public interface IAccountRepository
{
    Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default);
}
