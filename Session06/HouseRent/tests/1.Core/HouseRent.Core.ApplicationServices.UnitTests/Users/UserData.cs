using HouseRent.Core.Domain.Users;

namespace HouseRent.Core.ApplicationServices.UnitTests.Users;

internal static class UserData
{
    public static User Create() => User.Create(Id,FirstName, LastName, Email);
    public static readonly long Id = 1;
    public static readonly FirstName FirstName = new("Alireza");
    public static readonly LastName LastName = new("Oroumand");
    public static readonly Email Email = new("ar.oroumand@gmail.com");
}
