using FluentValidation;
using HouseRent.Core.ApplicationService.Extentions.Behaviors.Logging;
using HouseRent.Core.ApplicationService.Extentions.Behaviors.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace HourseRent.Core.Applicaiton.Extentions.DependencyInjection;
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
