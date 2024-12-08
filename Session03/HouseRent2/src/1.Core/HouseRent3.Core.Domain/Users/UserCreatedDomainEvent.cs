using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Users;

public sealed record UserCreatedDomainEvent(int UserId) : IDomainEvent;