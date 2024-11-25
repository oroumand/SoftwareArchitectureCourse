namespace BuildingBlocks.AggregateSamples.Framework;

public abstract class BaseAggregateRoot<TId> : BaseEntity<TId>
{
    protected BaseAggregateRoot(TId id) : base(id)
    {
    }

    private readonly List<IDomainEvent> _events = [];


    protected void AddDomainEvent(IDomainEvent e)
    {
        _events.Add(e);
    }
    protected void ClearDomainEvent(IDomainEvent e)
    {
        _events.Clear();
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _events;
}
