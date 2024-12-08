
using HouseRent.Core.Domain.Shared;

namespace HouseRent.Core.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod,
    Money AmenitiesUpCharge);