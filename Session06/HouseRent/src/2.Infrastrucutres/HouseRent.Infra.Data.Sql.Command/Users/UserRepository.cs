using HouseRent.Core.Domain.Users;
using HouseRent.Infra.Data.Sql.Command.Framework;
using HouseRent.Infra.Data.Sql.Command.Shared;

namespace HouseRent.Infra.Data.Sql.Command.Users;

internal sealed class UserRepository(HouseRentDbContext dbContext) :
    BaseCommandRepository<User, long>(dbContext), IUserRepository
{
}