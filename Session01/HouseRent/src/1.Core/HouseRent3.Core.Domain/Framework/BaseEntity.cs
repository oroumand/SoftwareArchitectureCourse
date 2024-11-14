namespace HouseRent.Core.Domain.Framework;
public abstract class BaseEntity<TId>(TId id)
{
    private readonly List<IDomainEvent> _events = [];

    public TId Id { get; set; } = id;

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
