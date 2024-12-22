using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Shared;

namespace HouseRent.Core.Domain.Homes;

public sealed class Home : AggregateRoot<long>
{
    private Home(
        long  id,
        Title title,
        Description description,
        Address address,
        Money price,
        List<int> amenities)
        : base(id)
    {
        Title = title;
        Description = description;
        Address = address;
        Price = price;
        Amenities = amenities;
    }

    public Title Title { get; private set; }

    public Description Description { get; private set; }

    public Address Address { get; private set; }

    public Money Price { get; private set; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public List<int> Amenities { get; private set; } = [];

    public static Home Create(long  id,
        Title title,
        Description description,
        Address address,
        Money price,
        List<int> amenities)
    {
        Home home = new Home(id, title, description, address, price, amenities);
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