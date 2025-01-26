using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public sealed record ReviewCreatedDomainEvent(long ReviewId) : IDomainEvent;