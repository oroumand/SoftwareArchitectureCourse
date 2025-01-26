namespace CourseStore.Framework.Domain;

public abstract class AggregateRoot<TId> : BaseEntity<TId>, IAggregateRoot
{
    protected AggregateRoot(TId id) : base(id)
    {

    }
    protected AggregateRoot() : base()
    {

    }
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> Events() =>
        _domainEvents;


    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
