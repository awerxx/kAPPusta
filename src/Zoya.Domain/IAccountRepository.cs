using Avvr.Kappusta.Zoya.Domain.Entities;

namespace Avvr.Kappusta.Zoya.Domain;

public interface IAccountRepository
{
    Task<IReadOnlyCollection<Account>> GetAccountsAsync(CancellationToken cancellationToken = default);
}