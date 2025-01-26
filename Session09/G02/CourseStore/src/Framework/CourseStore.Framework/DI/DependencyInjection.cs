using CourseStore.Framework.Behaviors.Logging;
using CourseStore.Framework.Behaviors.Validations;
using CourseStore.Framework.Services.DateTimeServices;
using CourseStore.Framework.Services.IdGeneratorServices;
using FluentValidation;
using IdGen.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Framework.DI;
public static class DependencyInjection
{
    public static IServiceCollection AddModularMonolithFramework(this IServiceCollection services,
                                                IConfiguration configuration, int idGeneratorId, List<Assembly> assembliesforScan)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddIdGen(idGeneratorId);
        services.AddSingleton<IIdGenerator<long>, SnowflakeIdGenerator>();

        services.AddValidatorsFromAssemblies(assembliesforScan);

        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssemblies([.. assembliesforScan]);
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}
