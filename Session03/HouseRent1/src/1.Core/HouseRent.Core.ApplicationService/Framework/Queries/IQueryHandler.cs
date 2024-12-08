﻿using HouseRent.Core.Domain.Framework;
using MediatR;

namespace HouseRent.Core.ApplicationService.Framework.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}