using HouseRent.Core.ApplicationServices.Framework.Queries;

namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;

public sealed record GetBookingQuery(int BookingId) : IQuery<BookingResponse>;