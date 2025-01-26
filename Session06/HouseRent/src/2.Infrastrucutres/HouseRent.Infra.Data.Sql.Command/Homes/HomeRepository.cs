using HouseRent.Core.Domain.Homes;
using HouseRent.Infra.Data.Sql.Command.Framework;
using HouseRent.Infra.Data.Sql.Command.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRent.Infra.Data.Sql.Command.Homes;

internal sealed class HomeRepository(HouseRentDbContext dbContext) : BaseCommandRepository<Home,long>(dbContext), IHomeRepository
{
    public async Task<Home?> GetGraphByIdAsync(long Id, CancellationToken cancellationToken = default)
    {
        
        return await DbContext.Homes.Include(c=>c.HomeAmenities).ThenInclude(c=>c.Amenity).Where(c=>c.Id==Id).FirstAsync(cancellationToken);
    }
}