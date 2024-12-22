using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Shared;
using HouseRent.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Command.Bookings;

internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.HasKey(booking => booking.Id);
        builder.Property(booking => booking.PriceForPeriod)
           .HasConversion(price => price.Amount, value => new Money(value));
        builder.Property(booking => booking.AmenitiesUpCharge)
           .HasConversion(price => price.Amount, value => new Money(value));
        builder.OwnsOne(booking => booking.Duration);
        builder.HasOne<Home>()
            .WithMany()
            .HasForeignKey(booking => booking.HomeId);
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(booking => booking.UserId);
    }
}