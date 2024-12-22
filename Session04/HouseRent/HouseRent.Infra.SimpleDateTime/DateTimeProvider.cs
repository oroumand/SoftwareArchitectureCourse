using HouseRent.Core.ApplicationServices.Contracts;

namespace HouseRent.Infra.SimpleDateTime;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}