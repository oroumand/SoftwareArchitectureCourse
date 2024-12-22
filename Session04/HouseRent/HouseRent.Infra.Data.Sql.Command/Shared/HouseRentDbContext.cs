using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Users;
using HouseRent.Infra.Data.Sql.Command.Framework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HouseRent.Infra.Data.Sql.Command.Shared;

public sealed class HouseRentDbContext(DbContextOptions options, IPublisher publisher) : BaseCommandDbContext(options)
{
    private readonly IPublisher _publisher = publisher;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HouseRentDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            SaveDomainEvents();
            var result = await base.SaveChangesAsync(cancellationToken);

            //await PublishDomainEventsAsync();

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new DbUpdateConcurrencyException("Concurrency exception occurred.", ex);
        }
    }
    public DbSet<User> Users{ get; set; }
    public DbSet<Amenity> Amenities{ get; set; }
    public DbSet<Home> Homes{ get; set; }
    public DbSet<Booking> Bookings{ get; set; }
    private async Task PublishDomainEventsAsync()
    {
        List<IDomainEvent> domainEvents =
            ChangeTracker
                    .Entries<IAggregateRoot>()
                    .Select(entry => entry.Entity)
                    .SelectMany(entity =>
                    {
                        var domainEvents = entity.Events();

                        entity.ClearDomainEvents();


                        return domainEvents;
                    })
                    .ToList();
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }




}