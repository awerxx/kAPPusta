using Avvr.Kappusta.Zoya.Application.Accounts.Responses;

namespace Avvr.Kappusta.Zoya.Web.Data;

public class AccountService
{
    private readonly HttpClient         _httpClient;

    public AccountService(HttpClient httpClient)
    {
        _httpClient   = httpClient;
    }

    public async Task<AccountResponse[]> GetAccountsAsync()
    {
        var accounts = await _httpClient.GetFromJsonAsync<AccountListResponse>("https://localhost:7035/api/accounts");

        return accounts.Accounts.ToArray();
    }
}
