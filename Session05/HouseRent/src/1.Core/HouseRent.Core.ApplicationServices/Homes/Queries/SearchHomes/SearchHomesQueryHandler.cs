using Dapper;
using HouseRent.Core.ApplicationServices.Contracts;
using HouseRent.Core.ApplicationServices.Framework.Queries;
using HouseRent.Core.Domain.Bookings;
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.ApplicationServices.Homes.Queries.SearchHomes;

internal sealed class SearchHomesQueryHandler
    : IQueryHandler<SearchHomesQuery, IReadOnlyList<HomeResponse>>
{
    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
    };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchHomesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<HomeResponse>>> Handle(SearchHomesQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<HomeResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                h.Id AS Id,
                h.Title AS Title,
                h.Description AS Description,
                h.Address_City AS City,
                h.Address_AddressLine AS AddressLine,
                h.Address_ZipCode AS ZipCode,
                h.Price AS Price
            FROM Homes AS h
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM Bookings AS b
                WHERE
                    b.HomeId = h.Id AND
                    b.Duration_Start <= @EndDate AND
                    b.Duration_End >= @StartDate AND
                    b.status in (1,2)
            )
            """;

        var homes = await connection
            .QueryAsync<HomeResponse, AddressResponse, HomeResponse>(
                sql,
                (home, address) =>
                {
                    home.Address = address;

                    return home;
                },
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                },
                splitOn: "City");

        return homes.ToList();
    }
}