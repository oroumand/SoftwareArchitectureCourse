using FluentAssertions;
using HouseRent.Core.Domain.UnitTests.Framework;
using HouseRent.Core.Domain.Users;

namespace HouseRent.Core.Domain.UnitTests.Users;

public class UserTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var user = User.Create(UserData.Id, UserData.FirstName, UserData.LastName, UserData.Email);

        // Assert
        user.Id.Should().Be(UserData.Id);
        user.FirstName.Should().Be(UserData.FirstName);
        user.LastName.Should().Be(UserData.LastName);
        user.Email.Should().Be(UserData.Email);
    }

    [Fact]
    public void Create_Should_RaiseUserCreatedDomainEvent()
    {
        // Act
        var user = User.Create(UserData.Id, UserData.FirstName, UserData.LastName, UserData.Email);

        // Assert
        var userCreatedDomainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent,long>(user);

        userCreatedDomainEvent.UserId.Should().Be(user.Id);
    }
}