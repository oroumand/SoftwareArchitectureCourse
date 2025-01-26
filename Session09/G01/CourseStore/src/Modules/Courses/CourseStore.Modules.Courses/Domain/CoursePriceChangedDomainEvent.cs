using CourseStore.Framework.Domain;

namespace CourseStore.Modules.Courses.Domain;

public record CoursePriceChangedDomainEvent(long Id, int Price) : IDomainEvent;