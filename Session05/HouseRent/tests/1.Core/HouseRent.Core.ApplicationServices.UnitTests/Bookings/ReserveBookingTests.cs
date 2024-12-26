using FluentAssertions;
using HouseRent.Core.ApplicationServices.Bookings.Commands.ReserveBooking;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.ApplicationServices.UnitTests.Users;
using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Users;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace HouseRent.Core.ApplicationServices.UnitTests.Bookings;

public class ReserveBookingTests
{
    private static readonly DateTime UtcNow = DateTime.UtcNow;
    private static readonly ReserveBookingCommand Command = new(
        1,
        1,
        new DateOnly(2025, 1, 1),
        new DateOnly(2025, 1, 7));

    private readonly ReserveBookingCommandHandler _handler;
    private readonly IUserRepository _userRepositoryMock;
    private readonly IHomeRepository _apartmentRepositoryMock;
    private readonly IBookingRepository _bookingRepositoryMock;
    private readonly IAmentyRepository _amentyRepository;

    private readonly IUnitOfWork _unitOfWorkMock;

    public ReserveBookingTests()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _apartmentRepositoryMock = Substitute.For<IHomeRepository>();
        _bookingRepositoryMock = Substitute.For<IBookingRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _amentyRepository = Substitute.For<IAmentyRepository>();

        IDateTimeProvider dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
        IIdGenerator<long> idGenerator = Substitute.For<IIdGenerator<long>>();

        dateTimeProviderMock.GetUtcNow().Returns(UtcNow);
        idGenerator.GetId().Returns(1);
        _handler = new ReserveBookingCommandHandler(idGenerator,
            _userRepositoryMock,
            _apartmentRepositoryMock,
            _bookingRepositoryMock,
            _amentyRepository,
            _unitOfWorkMock,
            dateTimeProviderMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenUserIsNull()
    {
        // Arrange
        _userRepositoryMock
            .GetByIdAsync(Command.UserId, Arg.Any<CancellationToken>())
            .Returns((User?)null);

        // Act
        var result = await _handler.Handle(Command, default);

        // Assert
        result.Error.Should().Be(UserErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenHomeIsNull()
    {
        // Arrange
        var user = UserData.Create();

        _userRepositoryMock
            .GetByIdAsync(Command.UserId, Arg.Any<CancellationToken>())
            .Returns(user);

        _apartmentRepositoryMock
            .GetByIdAsync(Command.HomeId, Arg.Any<CancellationToken>())
            .Returns((Home?)null);

        // Act
        var result = await _handler.Handle(Command, default);

        // Assert
        result.Error.Should().Be(HomeErrors.NotFound);
    }

    

    
}