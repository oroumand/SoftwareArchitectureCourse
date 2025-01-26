using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.Domain.Amenities;
public class Amenity : AggregateRoot<long>
{
    private Amenity(long id,
                    Title title,
                    Money price) : base(id)
    {
        Title = title;
        Price = price;
    }

    public Title Title { get; set; }
    public Money Price { get; set; }


    public static Amenity Create(long id, Title title, Money price)
    {
        var amenity = new Amenity(id, title, price);
        amenity.AddDomainEvent(new AmenityCreatedDomainEvent(id));
        return amenity;
    }
}
