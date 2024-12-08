using HouseRent.Core.Domain.Framework;
using MediatR;

namespace HouseRent.Core.ApplicationService.Framework.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
