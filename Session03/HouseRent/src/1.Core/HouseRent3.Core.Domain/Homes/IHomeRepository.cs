namespace HouseRent.Core.Domain.Homes;

public interface IHomeRepository
{
    Task<Home?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}