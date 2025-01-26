using CourseStore.Framework.DI;
using MMCourseStore.Modules.DI;
using MMCourseStore.Modules.Endpoints;
using System.Reflection;

namespace MMCourseStore.Host.RestEndpoint.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        List<Assembly> assemblies = [typeof(Program).Assembly];
        builder.Services.AddCourseModule(builder.Configuration, assemblies);


        builder.Services.AddModularMonolithFramework(builder.Configuration, 1, assemblies);

        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapOpenApi();
        //app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapCourseEndpoint("/courses");
        app.MapControllers();

        return app;
    }
}
