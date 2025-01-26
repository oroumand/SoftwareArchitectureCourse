using CourseStore.Framework.Queries;

namespace CourseStore.Modules.CourseManagement.ApplicationServices.Query.GetById;

public record GetByIdCourseQuery(long Id) : IQuery<GetByIdCourseResponse>;

