using HouseRent.Core.ApplicationServices.Framework.Queries;

namespace HouseRent.Core.ApplicationServices.Homes.Queries.SearchHomes;

public sealed record SearchHomesQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<HomeResponse>>;