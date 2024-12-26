using HouseRent.Core.ApplicationServices.Homes.Queries.SearchHomes;
using HouseRent.Endpoints.RestAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.Endpoints.RestAPI.Controllers.Homes;
[Route("api/[controller]")]
[ApiController]
public class HomeController : HouseRentController
{
    public HomeController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> SearchHomes(DateOnly startDate,
                                                 DateOnly endDate,
                                                 CancellationToken cancellationToken)
    {
        var query = new SearchHomesQuery(startDate, endDate);

        var result = await CqrsSender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}
