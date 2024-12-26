using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.UnitTests.Framework;

public abstract class BaseTest
{
    public static TDomainEvent AssertDomainEventWasPublished<TDomainEvent, TId>(AggregateRoot<TId> aggregateRoot)
        where TDomainEvent : IDomainEvent
    {
        var domainEvent = aggregateRoot.Events().OfType<TDomainEvent>().SingleOrDefault();

        if (domainEvent == null)
        {
            throw new Exception($"{typeof(TDomainEvent).Name} was not published");
        }

        return domainEvent;
    }
}