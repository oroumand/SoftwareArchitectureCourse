
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public sealed record Rating
{

    private Rating(int value) => Value = value;

    public int Value { get; init; }

    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>(ReviewErrors.Invalid);
        }

        return new Rating(value);
    }
}