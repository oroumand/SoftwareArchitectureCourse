using HouseRent.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRent.Infra.Data.Sql.Command.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
            .HasMaxLength(50)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(user => user.LastName)
            .HasMaxLength(50)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(user => user.Email)
            .HasMaxLength(100)
            .HasConversion(email => email.Value, value => new Core.Domain.Users.Email(value)); ;

        builder.HasIndex(user => user.Email).IsUnique();
    }
}
