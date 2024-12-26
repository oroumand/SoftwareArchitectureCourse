namespace HouseRent.Endpoints.RestAPI.Controllers.Bookings;

public sealed record ReserveBookingRequest(
    long HomeId,
    long UserId,
    DateTime? StartDate,
    DateTime? EndDate);