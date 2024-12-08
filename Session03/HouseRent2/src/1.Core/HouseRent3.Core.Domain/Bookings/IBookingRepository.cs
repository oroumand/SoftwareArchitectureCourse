using HouseRent.Core.Domain.Homes;

namespace HouseRent.Core.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Home home,
        DateRange duration,
        CancellationToken cancellationToken = default);

    Task AddAsync(Booking booking, CancellationToken cancellationToken = default);
}