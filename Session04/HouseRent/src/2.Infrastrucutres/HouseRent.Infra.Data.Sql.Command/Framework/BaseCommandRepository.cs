using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Users;
using HouseRent.Infra.Data.Sql.Command.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRent.Infra.Data.Sql.Command.Framework;

internal abstract class BaseCommandRepository<TEntity, TId>(HouseRentDbContext dbContext)
    where TEntity : AggregateRoot<TId>
{
    protected readonly HouseRentDbContext DbContext = dbContext;

    


    public async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbContext.AddAsync(entity);
    }

}