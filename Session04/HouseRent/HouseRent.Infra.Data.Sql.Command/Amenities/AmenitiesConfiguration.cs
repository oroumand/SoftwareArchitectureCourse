using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Infra.Data.Sql.Command.Amenities;
internal class AmenitiesConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.ToTable("Amenities");
        builder.HasKey(x => x.Id);
        builder.Property(amenity => amenity.Title)
          .HasMaxLength(200)
          .HasConversion(title => title.Value, value => new Title(value));
        builder.Property(amenity => amenity.Price)
           .HasConversion(price => price.Amount, value => new Money(value));
    }
}
