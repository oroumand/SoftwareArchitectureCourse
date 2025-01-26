using HouseRent.Core.Domain.Homes;
using HouseRent.Core.Domain.Shared;

namespace HouseRent.Core.ApplicationServices.UnitTests.Homes;

internal static class HomeData
{
    public static Home Create(Money price) => Home.Create(
        1,
        new Title("آپارتمان شماره یک"),
        new Description("Test description"),
        new Address("تهران", "خیابان انقلاب", "1234567890"),
        price,
        []);
}