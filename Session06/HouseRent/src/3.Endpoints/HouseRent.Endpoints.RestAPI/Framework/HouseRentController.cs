using HouseRent.Core.ApplicationServices.Homes.Queries.SearchHomes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseRent.Endpoints.RestAPI.Framework;

public class HouseRentController:ControllerBase
{
    protected readonly ISender CqrsSender;
    public HouseRentController(ISender sender)
    {
        CqrsSender = sender;
    }

}
