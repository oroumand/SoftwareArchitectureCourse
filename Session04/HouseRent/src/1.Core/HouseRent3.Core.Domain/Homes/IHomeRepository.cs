﻿namespace HouseRent.Core.Domain.Homes;

public interface IHomeRepository
{
    Task<Home?> GetByIdAsync(long  Id, CancellationToken cancellationToken = default);
}