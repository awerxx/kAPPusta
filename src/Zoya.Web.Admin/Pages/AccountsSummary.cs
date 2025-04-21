using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Web.Admin.Data;
using Microsoft.AspNetCore.Components;

namespace Avvr.Kappusta.Zoya.Web.Admin.Pages;

// AccountsSummary.razor extension
#pragma warning disable CA1515
public partial class AccountsSummary
#pragma warning restore CA1515
{
#pragma warning disable IDE0052
    private AccountResponse[]? _accountResponse;
#pragma warning restore IDE0052

    [Inject]
    internal AccountService? AccountService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await AccountService!.GetAccountsAsync(CancellationToken.None);
        _accountResponse = response.Accounts;
    }
}