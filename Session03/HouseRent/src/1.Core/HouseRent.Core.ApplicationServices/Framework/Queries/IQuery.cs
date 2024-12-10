using HouseRent.Core.Domain.Framework;
using MediatR;

namespace HouseRent.Core.ApplicationServices.Framework.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}