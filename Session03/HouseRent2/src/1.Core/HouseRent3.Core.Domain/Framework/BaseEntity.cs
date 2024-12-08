using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.Domain.Framework;

public abstract class BaseEntity<TId>(TId id)
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; init; } = id;

    public IReadOnlyList<IDomainEvent> Events()=>
        _domainEvents.ToList();
    

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
