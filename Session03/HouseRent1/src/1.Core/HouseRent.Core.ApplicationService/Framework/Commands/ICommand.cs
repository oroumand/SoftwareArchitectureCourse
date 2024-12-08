using HouseRent.Core.Domain.Framework;
using MediatR;

namespace HouseRent.Core.ApplicationService.Framework.Commands;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}
