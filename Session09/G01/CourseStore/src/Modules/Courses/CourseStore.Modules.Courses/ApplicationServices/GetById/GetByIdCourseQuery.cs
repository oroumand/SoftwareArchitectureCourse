using CourseStore.Framework.Queries;
using CourseStore.Modules.Courses.ApplicationServices.GetById;

namespace MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetById;

public record GetByIdCourseQuery(long Id) : IQuery<GetByIdCourseResponse>;

