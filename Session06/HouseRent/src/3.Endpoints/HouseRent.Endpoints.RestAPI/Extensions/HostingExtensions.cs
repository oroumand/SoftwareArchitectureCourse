using HouseRent.Core.ApplicationServices.Extentions.DependencyInjection;
using HouseRent.Infra.Data.Sql.Command.Shared;
using HouseRent.Infra.Extentions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;

namespace HouseRent.Endpoints.RestAPI.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {
        var connectionString =
            builder.Configuration.GetConnectionString("CnnString") ??
            "throw new ArgumentNullException(nameof(configuration))";
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.RegisterApplicaitonService();
        builder.Services.RegisterDateTimeProvider();
        builder.Services.RegisterFakeEmailService();
        builder.Services.RegisterSnowflakeIdGeneratorService(1);
        builder.Services.AddDbContext<HouseRentDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.RegisterDataAccessService(builder.Configuration);
        builder.Services.RegisterStackExchangeRedis(builder.Configuration);
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();
        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapOpenApi();
        app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}
