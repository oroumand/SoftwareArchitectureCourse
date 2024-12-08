using HourseRent.Core.Applicaiton.Contracts;
using HouseRent.Core.ApplicationService.Bookings.Commands;
using HouseRent.Core.ApplicationService.Contracts;
using HouseRent.Core.ApplicationService.Framework.Commands;
using HouseRent.Core.Domain.Amenities;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;
using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Users;
using MediatR;

namespace HourseRent.Core.Applicaiton.Bookings.Commands.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, int>
{
    #region private fields
    private readonly IdGenerator _idGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IHomeRepository _homeRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IAmentyRepository _amentyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;
    #endregion

    #region Constructors
    public ReserveBookingCommandHandler(
IdGenerator idGenerator,
IUserRepository userRepository,
IHomeRepository homeRepository,
IBookingRepository bookingRepository,
IAmentyRepository amentyRepository,
IUnitOfWork unitOfWork,

IDateTimeProvider dateTimeProvider)
    {
        _idGenerator = idGenerator;
        _userRepository = userRepository;
        _homeRepository = homeRepository;
        _bookingRepository = bookingRepository;
        _amentyRepository = amentyRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    } 
    #endregion

    public async Task<Result<int>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<int>(UserErrors.NotFound);
        }

        var home = await _homeRepository.GetByIdAsync(request.HomeId, cancellationToken);

        if (home is null)
        {
            return Result.Failure<int>(HomeErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);


        if (await _bookingRepository.IsOverlappingAsync(home, duration, cancellationToken))
        {
            return Result.Failure<int>(BookingErrors.Overlap);
        }


        List<Amenity> homeAmenities = home.Amenities.Any() ?
                await _amentyRepository.GetAmenitiesAsync(home.Amenities, cancellationToken) :
                [];

        PricingService pricingService = new(homeAmenities);

        var booking = Booking.Reserve(
            _idGenerator.GetId(),
            home,
            user.Id,
            duration,
            _dateTimeProvider.GetUtcNow(),
            pricingService);

        await _bookingRepository.AddAsync(booking, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return booking.Id;
    }


}