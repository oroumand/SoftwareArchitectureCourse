using Dapper;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.ApplicationServices.Framework.Queries;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.ApplicationServices.Bookings.Queries.GetBooking;

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

        const string query = """
            SELECT [Id]
                ,[HomeId]
                ,[UserId]
                ,[Duration_Start] as DurationStart
                ,[Duration_End] as DurationEnd
                ,[PriceForPeriod]
                ,[AmenitiesUpCharge]
                ,[Status]
                ,[CreatedOnUtc]
                ,[HostStatusOnUtc]
                ,[GuestStatusOnUtc]
            FROM [dbo].[Bookings]
            Where Id = @BookingId

            """;

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(query, new { request.BookingId });

        return booking;
    }
}