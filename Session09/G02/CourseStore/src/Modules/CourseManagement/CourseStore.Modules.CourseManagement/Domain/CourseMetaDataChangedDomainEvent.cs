using CourseStore.Framework.Domain;
using CourseStore.Framework.Domain;

namespace CourseStore.Modules.CourseManagement.Domain;
public record CourseMetaDataChangedDomainEvent(long Id,
                                       string Title,
                                       string Description,
                                       DateTime StartDate,
                                       int SessionCount) : IDomainEvent;