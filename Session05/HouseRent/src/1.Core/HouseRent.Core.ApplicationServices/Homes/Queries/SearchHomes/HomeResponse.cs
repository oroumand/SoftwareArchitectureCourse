namespace HouseRent.Core.ApplicationServices.Homes.Queries.SearchHomes;

public sealed class HomeResponse
{
    public long Id { get; init; }

    public string Title { get; init; }

    public string Description { get; init; }

    public int Price { get; init; }
    public AddressResponse Address { get; set; }
}