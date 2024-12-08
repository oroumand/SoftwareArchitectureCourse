using HouseRent.Core.ApplicationService.Framework.Commands;

namespace HouseRent.Core.ApplicationService.Bookings.Commands;

public record ReserveBookingCommand(
    int HomeId,
    int UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<int>;