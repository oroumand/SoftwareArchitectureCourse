using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Infra.SimpleEmail;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Extentions.DependencyInjection;
public static class FakeEmailRegistrer
{
    public static IServiceCollection RegisterApplicaitonService(this IServiceCollection services)
    {
        services.AddTransient<IEmailService, FakeEmailService>();
        return services;
    }
}
