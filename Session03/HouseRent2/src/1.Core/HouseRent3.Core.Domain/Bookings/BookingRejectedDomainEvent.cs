using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Bookings;

public sealed record BookingRejectedDomainEvent(int BookingId) : IDomainEvent;