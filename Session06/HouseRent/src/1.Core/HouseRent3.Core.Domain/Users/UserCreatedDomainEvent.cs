using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Users;

public sealed record UserCreatedDomainEvent(long UserId) : IDomainEvent;