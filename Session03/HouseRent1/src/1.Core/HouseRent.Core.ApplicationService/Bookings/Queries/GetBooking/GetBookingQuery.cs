using HouseRent.Core.ApplicationService.Framework.Queries;

namespace HourseRent.Core.Applicaiton.Bookings.Queries.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;