using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Web.Admin.Data;
using Microsoft.AspNetCore.Components;

namespace Avvr.Kappusta.Zoya.Web.Admin.Pages;

public partial class Accounts
{
    private AccountResponse[]? _accounts;

    [Inject]
    public AccountService? AccountService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await AccountService!.GetAccountsAsync(CancellationToken.None);
        _accounts = response.Accounts;
    }
}