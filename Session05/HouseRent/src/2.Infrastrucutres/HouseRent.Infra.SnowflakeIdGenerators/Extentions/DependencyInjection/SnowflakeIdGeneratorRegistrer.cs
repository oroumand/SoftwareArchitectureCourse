using Microsoft.Extensions.DependencyInjection;
using IdGen.DependencyInjection;
using HouseRent.Infra.SnowflakeIdGenerators;
namespace HouseRent.Infra.Extentions.DependencyInjection;
public static class SnowflakeIdGeneratorRegistrer
{
    public static IServiceCollection RegisterSnowflakeIdGeneratorService(this IServiceCollection services,
                                                                         int idGeneratorId)
    {

        services.AddIdGen(idGeneratorId);
        services.AddSingleton<Core.ApplicationServices.Contracts.IIdGenerator<long>, SnowflakeIdGenerator>();
        return services;
    }
}
