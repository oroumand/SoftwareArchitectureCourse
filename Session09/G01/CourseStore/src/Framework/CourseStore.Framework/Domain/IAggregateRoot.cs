namespace CourseStore.Framework.Domain;

public interface IAggregateRoot
{
    void ClearDomainEvents();
    IReadOnlyList<IDomainEvent> Events();
}