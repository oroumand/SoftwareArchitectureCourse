namespace HouseRent.Core.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long  Id, CancellationToken cancellationToken = default);

    Task Add(User user, CancellationToken cancellationToken = default);
}