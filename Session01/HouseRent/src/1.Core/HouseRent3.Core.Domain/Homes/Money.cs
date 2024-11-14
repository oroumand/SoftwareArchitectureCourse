namespace HouseRent.Core.Domain.Homes;

public record Money(int Amount)
{
    public static Money operator +(Money first, Money second)
    {

        return new Money(first.Amount + second.Amount);
    }

    public static int Zero => 0;
    public bool IsZero() => Amount == Zero;
}