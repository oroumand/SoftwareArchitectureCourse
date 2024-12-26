using System.Reflection.Metadata.Ecma335;

namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;

public sealed class BookingResponse
{
    public long Id { get; init; }

    public long UserId { get; init; }

    public int HomeId { get; init; }

    public int Status { get; init; }

    public int PriceForPeriod { get; init; }

    public int AmenitiesUpCharge { get; init; }

    public int TotalPriceAmount => PriceForPeriod + AmenitiesUpCharge;

    public DateOnly DurationStart { get; init; }

    public DateOnly DurationEnd { get; init; }

    public DateTime CreatedOnUtc { get; init; }
    public DateTime HostStatusOnUtc { get; set; }
    public DateTime GuestStatusOnUtc { get; set; }
}