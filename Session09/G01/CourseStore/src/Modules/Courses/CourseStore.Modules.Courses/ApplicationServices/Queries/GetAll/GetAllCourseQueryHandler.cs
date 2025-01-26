using CourseStore.Framework.Domain;
using CourseStore.Framework.Queries;
using CourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
using CourseStore.Modules.Courses.Data;
using Microsoft.EntityFrameworkCore;

namespace MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
internal class GetAllCourseQueryHandler(CourseDbContext context) : IQueryHandler<GetAllCourseQuery, List<GetAllCourseResponse>>
{
    public async Task<Result<List<GetAllCourseResponse>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        List<GetAllCourseResponse> result = await context.Courses.Select(c => new GetAllCourseResponse
        (
            c.Id,
             c.Title,
            c.Teacher
        )).ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
