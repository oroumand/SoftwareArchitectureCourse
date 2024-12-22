using HouseRent.Core.Domain.Homes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Command.Homes;

internal sealed class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.ToTable("Homes");

        builder.HasKey(home => home.Id);

        builder.OwnsOne(home => home.Address);

        builder.Property(home => home.Title)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Title(value));

        builder.Property(home => home.Description)
            .HasConversion(description => description.Value, value => new Description(value));
        builder.Property(home => home.Price)
            .HasConversion(price => price.Amount, value => new Core.Domain.Shared.Money(value));


        builder.Property<uint>("Version").IsRowVersion();
    }
}