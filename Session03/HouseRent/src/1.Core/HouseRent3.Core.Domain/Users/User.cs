
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Users;

public sealed class User : AggregateRoot<int>
{
    private User(int id, FirstName firstName, LastName lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public static User Create(int id,FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(id, firstName, lastName, email);

        user.AddDomainEvent(new UserCreatedDomainEvent(id));

        return user;
    }
}