using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Shared;

namespace HouseRent.Core.Domain.Homes;

public sealed class Home : AggregateRoot<long>
{
    private Home(
        long id,
        Title title,
        Description description,
        Address address,
        Money price,
        List<HomeAmenity> amenities)
        : base(id)
    {
        Title = title;
        Description = description;
        Address = address;
        Price = price;
        HomeAmenities = amenities;
    }
    private Home() : base()
    {

    }
    public Title Title { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<HomeAmenity> HomeAmenities { get; private set; } = [];

    public static Home Create(long id,
        Title title,
        Description description,
        Address address,
        Money price,
        List<HomeAmenity> amenities)
    {
        Home home = new(id, title, description, address, price, amenities);
        home.AddDomainEvent(new HomeCreated(id));
        return home;
    }

    public Result Reserve(DateTime dateTimeUtc)
    {
        LastBookedOnUtc = dateTimeUtc;
        AddDomainEvent(new HomeBooked(Id));
        return Result.Success();
    }
}
