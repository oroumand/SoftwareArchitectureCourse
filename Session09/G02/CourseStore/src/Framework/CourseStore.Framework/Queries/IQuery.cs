using CourseStore.Framework.Domain;
using MediatR;

namespace CourseStore.Framework.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}