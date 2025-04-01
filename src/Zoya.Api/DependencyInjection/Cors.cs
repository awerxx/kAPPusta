namespace Avvr.Kappusta.Zoya.Api.DependencyInjection;

internal static class Cors
{
    public static void ConfigureCors(this IServiceCollection services)
        => services.AddCors(
            options => options.AddPolicy(
                "CorsPolicy",
                policyBuilder =>
                {
                    policyBuilder.AllowAnyMethod()
                                 .AllowAnyHeader()
                                 .WithOrigins("http://localhost:5000", "https://localhost:5001")
                                 .AllowCredentials();
                }));
}