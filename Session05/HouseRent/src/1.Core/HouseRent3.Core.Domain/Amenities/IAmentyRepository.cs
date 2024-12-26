using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Homes;

namespace HouseRent.Core.Domain.Amenities;

public interface IAmentyRepository
{
    Task<Amenity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<Amenity>> GetAmenitiesAsync(List<long> amenityIds, CancellationToken cancellationToken = default);



}