using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public sealed record ReviewCreatedDomainEvent(int ReviewId) : IDomainEvent;