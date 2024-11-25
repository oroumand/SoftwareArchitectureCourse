using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
    }

    public DateOnly Start { get; init; }

    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new DomainValidationException("تاریخ پایان از شروع کوچکتر است");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}

public class InvalidDateRangeException : DomainValidationException
{

}