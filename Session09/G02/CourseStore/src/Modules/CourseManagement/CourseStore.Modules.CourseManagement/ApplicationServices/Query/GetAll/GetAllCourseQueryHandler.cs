using CourseStore.Modules.CourseManagement.Data;
using Microsoft.EntityFrameworkCore;
using CourseStore.Framework.Domain;
using CourseStore.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Modules.CourseManagement.ApplicationServices.Query.GetAll;
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
