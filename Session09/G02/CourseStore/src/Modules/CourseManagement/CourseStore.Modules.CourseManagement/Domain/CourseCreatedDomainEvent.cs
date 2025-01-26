using CourseStore.Framework.Domain;

namespace CourseStore.Modules.CourseManagement.Domain;

public record CourseCreatedDomainEvent(long Id,
                                       string Title,
                                       string Description,
                                       DateTime StartDate,
                                       int SessionCount,
                                       int Price) : IDomainEvent;