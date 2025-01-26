using CourseStore.Framework.Domain;
using CourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CourseStore.Modules.Courses.Endpoints;
public static class CourseEndpoints
{
    public static WebApplication MapCourseEndpoint(this WebApplication app, string route)
    {
        app.MapGet(route, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllCourseQuery());
            return TypedResults.Ok(result);
        });
        return app;
    }
}
