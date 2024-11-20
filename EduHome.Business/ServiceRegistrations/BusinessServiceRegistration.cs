using EduHome.Business.Services.Abstractions;
using EduHome.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EduHome.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        AddServices(services);

        return services;
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
    }
}
