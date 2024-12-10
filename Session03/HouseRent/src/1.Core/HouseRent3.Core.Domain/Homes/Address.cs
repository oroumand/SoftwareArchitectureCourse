namespace HouseRent.Core.Domain.Homes;

public record Address(
    string City,
    string AddressLine,
    string ZipCode);