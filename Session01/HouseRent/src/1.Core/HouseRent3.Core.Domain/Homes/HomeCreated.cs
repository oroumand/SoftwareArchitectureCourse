using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Homes
{
    public record HomeCreated(int id) : IDomainEvent;
}
