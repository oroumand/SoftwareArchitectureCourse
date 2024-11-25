using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildeingBlocks02;
internal class Person
{
    public FirstName FirstName { get; set; }
    public LastName LastName { get; set; }
}


public record FirstName(string firstName);
public record LastName(string lastName);


public record Email
{
    public string Value { get; init; }
    public string Value2 { get; init; }
    public string Value4 { get; init; }
    public string Value5 { get; init; }

    public Email(string value)
    {
        //Validation

        Value = value;
    }
}

public class Email2 : BaseValueObject<Email2>
{
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class Color : BaseValueObject<Color>
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }


    public static Color operator +(Color a, Color b)
    {
        return new Color
        {
            R = a.R + b.R,
            G = a.G + b.G,
            B = a.B + b.B,
        };
    }
}
public abstract class BaseValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : BaseValueObject<TValueObject>
{
    public bool Equals(TValueObject other) => this == other;

    public override bool Equals(object obj)
    {
        if (obj is TValueObject otherObject)
        {
            return GetEqualityComponents().SequenceEqual(otherObject.GetEqualityComponents());
        }
        return false;
    }
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
    protected abstract IEnumerable<object> GetEqualityComponents();
    public static bool operator ==(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
    {
        if (right is null && left is null)
            return true;
        if (right is null || left is null)
            return false;
        return right.Equals(left);
    }
    public static bool operator !=(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left) => !(right == left);


}