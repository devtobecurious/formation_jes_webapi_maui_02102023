using SuiviDesWookiees.Libs.Services;

namespace SuiviDesWookiees.Web.API.AppCode.Extensions;
public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddSingleton<IStringToUpperService, StringToUpperService>();
        services.AddScoped<IWookieeService, OracleDatabaseWookieeService>();

        return services;
    }
}

