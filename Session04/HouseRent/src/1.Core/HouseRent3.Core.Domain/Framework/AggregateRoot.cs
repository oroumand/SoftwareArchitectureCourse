namespace HouseRent.Core.Domain.Framework;

public abstract class AggregateRoot<TId>(TId id) : BaseEntity<TId>(id), IAggregateRoot
{

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> Events() =>
        [.. _domainEvents];


    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
