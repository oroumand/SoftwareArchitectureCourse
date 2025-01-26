using HouseRent.Core.ApplicationServices.Extentions.Behaviors.QueryCahing;
using HouseRent.Core.ApplicationServices.Framework.Queries;

namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;

public sealed record GetBookingQuery(long BookingId) : ICachedQuery<BookingResponse>
{
    public string CacheKey => $"GET_BOOKING_QUERY_BY_ID_{BookingId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(10);
}
