using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Homes;

namespace HouseRent.Core.Domain.Amenities;

public interface IAmentyRepository
{
    Task<Booking?> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    void AddAsync(Booking booking, CancellationToken cancellationToken = default);
    Task<List<Amenity>> GetAmenitiesAsync(List<int> amenityIds, CancellationToken cancellationToken = default);

}