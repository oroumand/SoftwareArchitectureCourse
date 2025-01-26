using CourseStore.Framework.DI;
using CourseStore.Modules.Courses.Endpoints;
using CourseStore.Modules.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Reflection;

namespace CourseStore.Host.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers();

        builder.Services.AddOpenApi();

        List<Assembly> assemblies = [typeof(Program).Assembly];

        builder.Services.AddCourseModule(builder.Configuration, assemblies);
        //builder.Services.AddStudentModule(builder.Configuration, assemblies);
        //builder.Services.AddOrderModule(builder.Configuration, assemblies);
        builder.Services.AddModularMonolithFramework(builder.Configuration, 1, assemblies);

        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.MapOpenApi();
        //app.MapScalarApiReference();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapCourseEndpoint("/courses");
        //app.MapStudentEndpoint("/students");
        //app.MapOrderEndpoint("/orders");
        return app;
    }
}
