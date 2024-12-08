using Dapper;
using HouseRent.Core.ApplicationService.Contracts;
using HouseRent.Core.ApplicationService.Framework.Queries;
using HouseRent.Core.Domain.Framework;

namespace HourseRent.Core.Applicaiton.Bookings.Queries.GetBooking;

internal sealed class GetBookingQueryHandler : IQueryHandler<GetBookingQuery, BookingResponse>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetBookingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string query = "SELECT * FROM bookings WHERE id = @BookingId";

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(query, new { request.BookingId });

        return booking;
    }
}