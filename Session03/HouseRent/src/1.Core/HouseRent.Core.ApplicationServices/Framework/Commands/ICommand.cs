using HouseRent.Core.Domain.Framework;
using MediatR;

namespace HouseRent.Core.ApplicationServices.Framework.Commands;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}