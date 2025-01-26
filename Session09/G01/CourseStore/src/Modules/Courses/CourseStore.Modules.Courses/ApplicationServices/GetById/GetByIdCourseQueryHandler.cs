using CourseStore.Framework.Domain;
using CourseStore.Framework.Queries;
using CourseStore.Modules.Courses.Data;
using Microsoft.EntityFrameworkCore;
using MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetById;

namespace CourseStore.Modules.Courses.ApplicationServices.GetById;
internal class GetByIdCourseQueryHandler(CourseDbContext context) : IQueryHandler<GetByIdCourseQuery, GetByIdCourseResponse>
{
    public async Task<Result<GetByIdCourseResponse>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Courses.Where(c => c.Id == request.Id).Select(c => new GetByIdCourseResponse
        (
            c.Id,
             c.Title,
            c.Teacher,
            c.Price
        )).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return Result.Success<GetByIdCourseResponse>(result);
    }
}
