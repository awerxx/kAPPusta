using Avvr.Kappusta.Zoya.Core;
using Zoya.Web.Data;

namespace Avvr.Kappusta.Zoya.Web.Data;

public class WeatherForecastService
{
    private readonly IAccountRepository _accountRepository;

    public WeatherForecastService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    private static readonly string[] _summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        var accounts = await _accountRepository.GetAccountsAsync();

        return accounts.Select((a, index) => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = $"{a.Name} - {_summaries[Random.Shared.Next(_summaries.Length)]}"
        }).ToArray();
    }
}
