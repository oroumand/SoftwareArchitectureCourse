

using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public sealed class Review : BaseEntity<int>
{
    private Review(
        int id,
        int homeId,
        int bookingId,
        int userId,
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

    public int HomeId { get; private set; }

    public int BookingId { get; private set; }

    public int UserId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        int id,
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