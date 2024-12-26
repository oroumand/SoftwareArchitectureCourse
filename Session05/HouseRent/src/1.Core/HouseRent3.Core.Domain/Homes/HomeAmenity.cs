using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Homes;

public class HomeAmenity : BaseEntity<long>
{
    public HomeAmenity() { }
    public Home Home { get; set; }
    public Amenity Amenity { get; set; }
    public long HomeId { get; set; }
    public long AmenityId { get; set; }
}