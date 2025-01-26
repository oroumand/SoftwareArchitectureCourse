using CourseStore.Modules.CourseManagement.Data;
using Microsoft.EntityFrameworkCore;
using CourseStore.Framework.Domain;
using CourseStore.Framework.Queries;

namespace CourseStore.Modules.CourseManagement.ApplicationServices.Query.GetById;
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
