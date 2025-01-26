using CourseStore.Framework.Domain;
using CourseStore.Modules.CourseManagement.ApplicationServices.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MMCourseStore.Modules.Endpoints;
public static class CourseEndpoints
{
    public static WebApplication MapCourseEndpoint(this WebApplication app, string route)
    {
        app.MapGet(route,async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllCourseQuery());
            return TypedResults.Ok<Result<List<GetAllCourseResponse>>>(result);
        });
        return app;
    }
}
