using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Shared;

namespace HouseRent.Core.Domain.Bookings;

public sealed class Booking : AggregateRoot<long>
{
    private Booking(
        long id,
        long homeId,
        long userId,
        DateRange duration,
        Money priceForPeriod,
        Money amenitiesUpCharge,
        BookingStatus status,
        DateTime createdOnUtc)
        : base(id)
    {
        HomeId = homeId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        AmenitiesUpCharge = amenitiesUpCharge;
        Status = status;
        CreatedOnUtc = createdOnUtc;
    }
    private Booking():base()
    {
        
    }
    public long HomeId { get; private set; }

    public long UserId { get; private set; }

    public DateRange Duration { get; private set; }

    public Money PriceForPeriod { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }

    public Money TotalPrice => PriceForPeriod + AmenitiesUpCharge;

    public BookingStatus Status { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? HostStatusOnUtc { get; private set; }


    public DateTime? GuestStatusOnUtc { get; private set; }

    public static Booking Reserve(long id,
        Home home,
        long userId,
        DateRange duration,
        DateTime utcNow,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(home, duration);

        var booking = new Booking(
            id,
            home.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.AmenitiesUpCharge,
            BookingStatus.Reserved,
            utcNow);

        booking.AddDomainEvent(new BookingReservedDomainEvent(booking.Id));

        home.Reserve(utcNow);

        return booking;
    }

    public Result Confirm(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Confirmed;
        HostStatusOnUtc = utcNow;

        AddDomainEvent(new BookingConfirmedDomainEvent(Id));

        return Result.Success();
    }

    public Result Reject(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }

        Status = BookingStatus.Rejected;
        HostStatusOnUtc = utcNow;

        AddDomainEvent(new BookingRejectedDomainEvent(Id));

        return Result.Success();
    }

    public Result Complete(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        Status = BookingStatus.Completed;
        GuestStatusOnUtc = utcNow;

        AddDomainEvent(new BookingCompletedDomainEvent(Id));

        return Result.Success();
    }

    public Result Cancel(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if (currentDate > Duration.Start)
        {
            return Result.Failure(BookingErrors.AlreadyStarted);
        }

        Status = BookingStatus.Cancelled;
        GuestStatusOnUtc = utcNow;

        AddDomainEvent(new BookingCancelledDomainEvent(Id));

        return Result.Success();
    }
}