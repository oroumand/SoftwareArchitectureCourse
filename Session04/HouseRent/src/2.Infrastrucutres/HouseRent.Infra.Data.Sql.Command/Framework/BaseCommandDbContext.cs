using HouseRent.Core.Domain.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Infra.Data.Sql.Command.Framework;
public abstract class BaseCommandDbContext : DbContext
{
    protected BaseCommandDbContext()
    {
    }

    protected BaseCommandDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

    protected void SaveDomainEvents()
    {
        List<dynamic> changedAggregates = ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(x => x.State != EntityState.Detached)
            .Select(c => c.Entity as dynamic)
            .Where(c => c.GetEvents() != null && c.GetEvents().Count > 0)
            .ToList();

        if (changedAggregates is null || !changedAggregates.Any())
        {
            return;
        }

        string traceId = string.Empty;
        string spanId = string.Empty;

        if (Activity.Current != null)
        {
            traceId = Activity.Current.TraceId.ToHexString();
            spanId = Activity.Current.SpanId.ToHexString();
        }
        foreach (var aggregate in changedAggregates)
        {
            var domainEvents = aggregate.Events();
            foreach (object @event in domainEvents)
            {
                OutBoxEventItems.Add(new OutBoxEventItem
                {
                    EventId = Guid.NewGuid(),
                    AccuredByUserId = "default user",
                    AccuredOn = DateTime.Now,
                    AggregateId = aggregate.BusinessId.ToString(),
                    AggregateName = aggregate.GetType().Name,
                    AggregateTypeName = aggregate.GetType().FullName ?? aggregate.GetType().Name,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName ?? @event.GetType().Name,
                    EventPayload = System.Text.Json.JsonSerializer.Serialize(@event),
                    TraceId = traceId,
                    SpanId = spanId,
                    IsProcessed = false
                });
            }
        }

    }
}
