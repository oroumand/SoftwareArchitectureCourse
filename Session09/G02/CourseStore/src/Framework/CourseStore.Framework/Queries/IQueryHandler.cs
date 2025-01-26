using CourseStore.Framework.Domain;
using MediatR;

namespace CourseStore.Framework.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}