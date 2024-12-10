using FluentValidation;
using HourseRent.Core.Applicaiton.Extentions.Behaviors.Validations;
using HouseRent.Core.ApplicationServices.Extentions.Behaviors.Logging;
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
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationRegistrer).Assembly);

        return services;
    }
}
