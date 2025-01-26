using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Reviews;
using HouseRent.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Command.Reviews;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(review => review.Id);

        builder.Property(review => review.Rating)
            .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

        builder.Property(review => review.Comment)
            .HasMaxLength(500)
            .HasConversion(comment => comment.Value, value => new Comment(value));

        builder.HasOne<Home>()
            .WithMany()
            .HasForeignKey(review => review.HomeId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Booking>()
            .WithMany()
            .HasForeignKey(review => review.BookingId).OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(review => review.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}