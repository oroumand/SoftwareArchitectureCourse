using HouseRent.Core.ApplicationServices.Bookings.Commands.ReserveBooking;
using HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;
using HouseRent.Endpoints.RestAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.Endpoints.RestAPI.Controllers.Bookings;
[Route("api/[controller]")]
[ApiController]
public class BookingsController(ISender sender) : HouseRentController(sender)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(long id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        var result = await CqrsSender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        [FromBody]ReserveBookingRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            request.HomeId,
            request.UserId,
            DateOnly.FromDateTime(request.StartDate.Value),
            DateOnly.FromDateTime(request.EndDate.Value));

        var result = await CqrsSender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}
