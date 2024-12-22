

using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public sealed class Review : AggregateRoot<long>
{
    private Review(
        long  id,
        long homeId,
        long bookingId,
        long userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
        : base(id)
    {
        HomeId = homeId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    public long HomeId { get; private set; }

    public long BookingId { get; private set; }

    public long UserId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        long  id,
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }

        var review = new Review(
            id,
            booking.HomeId,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            createdOnUtc);

        review.AddDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}