using CourseStore.Framework.Domain;

namespace CourseStore.Modules.CourseManagement.Domain;

public record CoursePriceChangedDomainEvent(long Id, int Price) : IDomainEvent;