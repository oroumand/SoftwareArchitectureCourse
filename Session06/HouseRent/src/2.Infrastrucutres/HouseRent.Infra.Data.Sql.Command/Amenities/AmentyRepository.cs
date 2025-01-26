using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Infra.Data.Sql.Command.Framework;
using HouseRent.Infra.Data.Sql.Command.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Infra.Data.Sql.Command.Amenities;
internal class AmentyRepository(HouseRentDbContext dbContext) :
    BaseCommandRepository<Amenity, long>(dbContext), IAmentyRepository
{
    public async Task<List<Amenity>> GetAmenitiesAsync(List<long> amenityIds, CancellationToken cancellationToken = default)
    {
  
        return await DbContext.Amenities.Where(c => amenityIds.Any(d=>d == c.Id)).ToListAsync();
    }
}
