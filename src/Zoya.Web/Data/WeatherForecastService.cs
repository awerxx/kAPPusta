using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Core;
using Zoya.Web.Data;

namespace Avvr.Kappusta.Zoya.Web.Data;

public class WeatherForecastService
{
    private readonly HttpClient         _httpClient;

    public WeatherForecastService(HttpClient httpClient)
    {
        _httpClient   = httpClient;
    }

    public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        var accounts = await _httpClient.GetFromJsonAsync<AccountListResponse>("https://localhost:7035/accounts");

        return accounts.Accounts.Select((a, index) => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = a.Name
        }).ToArray();
    }
}
