using Avvr.Kappusta.Zoya.Application.Accounts.Responses;
using Avvr.Kappusta.Zoya.Domain;
using Avvr.Kappusta.Zoya.Domain.Entities;
using Mapster;

namespace Avvr.Kappusta.Zoya.Web.Admin.DependencyInjection;

internal static class MappingConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection _)
        => TypeAdapterConfig<Account, AccountResponse>.NewConfig()
                                                      .Map(
                                                          dest => dest.DisplayName,
                                                          src => $"{src.Name} ({src.Currency.ToDisplayName()})")
                                                      .Map(dest => dest.CurrencySymbol, src => src.Currency.ToSymbol())
                                                      .Map(dest => dest.Balance, src => src.Balance.Amount);
}