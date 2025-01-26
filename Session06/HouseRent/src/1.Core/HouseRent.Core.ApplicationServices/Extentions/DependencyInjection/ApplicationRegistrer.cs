using FluentValidation;
using HouseRent.Core.Applicaiton.Extentions.Behaviors.Validations;
using HouseRent.Core.ApplicationServices.Extentions.Behaviors.Logging;
using HouseRent.Core.ApplicationServices.Extentions.QueryCahing;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Core.ApplicationServices.Extentions.DependencyInjection;
public static class ApplicationRegistrer
{
    public static IServiceCollection RegisterApplicaitonService(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblyContaining(typeof(ApplicationRegistrer));
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            c.AddOpenBehavior(typeof(QueryCachingBehavior<,>));

        });
        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrer).Assembly);

        return services;
    }
}
