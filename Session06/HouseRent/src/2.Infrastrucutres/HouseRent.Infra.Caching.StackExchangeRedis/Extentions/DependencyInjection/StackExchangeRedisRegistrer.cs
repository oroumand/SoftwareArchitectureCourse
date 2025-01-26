using Dapper;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Users;
using HouseRent.Infra.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Extentions.DependencyInjection;
public static class StackExchangeRedisRegistrer
{
    public static IServiceCollection RegisterStackExchangeRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cache") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => { 
            options.Configuration = connectionString;
            options.InstanceName = "";
        });

        services.AddSingleton<ICacheService, CacheService>();
        return services;
    }
}
