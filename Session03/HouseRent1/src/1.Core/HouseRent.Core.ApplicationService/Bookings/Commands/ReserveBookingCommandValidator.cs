using FluentValidation;
using HouseRent.Core.ApplicationService.Bookings.Commands;

namespace HourseRent.Core.Applicaiton.Bookings.Commands.ReserveBooking;

public class ReserveBookingCommandValidator : AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.HomeId).NotEmpty();

        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}