using Avvr.Kappusta.Zoya.Application;

namespace Avvr.Kappusta.Zoya.WebUI.Data;

public class AccountsService(IAccountRepository accountRepository)
{
    private readonly IAccountRepository _accountRepository = accountRepository;

    public async Task<AccountResponse[]> GetAccountsAsync()
    {
        var accounts = await _accountRepository.GetAccountsAsync();

        return accounts.Select(account => new AccountResponse(account.Name)).ToArray();
    }
}