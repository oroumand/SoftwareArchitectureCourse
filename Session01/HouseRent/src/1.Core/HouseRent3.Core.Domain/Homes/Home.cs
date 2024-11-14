using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Homes
{
    public class Home : BaseEntity<int>
    {
        private Home(int id,
                     Title title,
                     Description description,
                     Money price,
                     List<int> amenities) : base(id)
        {
            Title = title;
            Description = description;
            Price = price;
            Amenities = amenities;
        }

        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public Money Price { get; private set; }
        public List<int> Amenities { get; private set; } = [];
        public DateTime? LastReservationDate { get; private set; }

        public static Home Create(int id,
                                  Title title,
                                  Description description,
                                  Money price,
                                  List<int> amenities)
        {
            var home = new Home(id, title, description, price, amenities);
            home.AddDomainEvent(new HomeCreated(id));
            return home;
        }
    }



}
