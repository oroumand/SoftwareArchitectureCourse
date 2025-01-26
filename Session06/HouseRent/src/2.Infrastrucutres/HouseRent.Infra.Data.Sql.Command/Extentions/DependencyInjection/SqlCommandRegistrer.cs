using Dapper;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Users;
using HouseRent.Infra.Data.Sql.Command.Amenities;
using HouseRent.Infra.Data.Sql.Command.Bookings;
using HouseRent.Infra.Data.Sql.Command.ConnectionFactory;
using HouseRent.Infra.Data.Sql.Command.Homes;
using HouseRent.Infra.Data.Sql.Command.Shared;
using HouseRent.Infra.Data.Sql.Command.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseRent.Infra.Extentions.DependencyInjection;
public static class SqlCommandRegistrer
{
    public static IServiceCollection RegisterDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
                    configuration.GetConnectionString("HouseRentCnn") ??
                    throw new ArgumentNullException("Connection String not found. check the name of connection string in configuration file");

        services.AddDbContext<HouseRentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IHomeRepository, HomeRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IAmentyRepository, AmentyRepository>();

        services.AddScoped<IUnitOfWork, UnitofWork>();
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());


        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        return services;
    }
}
