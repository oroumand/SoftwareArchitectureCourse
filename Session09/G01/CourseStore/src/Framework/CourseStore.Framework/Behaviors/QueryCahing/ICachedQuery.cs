using CourseStore.Framework.Queries;

namespace CourseStore.Framework.Behaviors.QueryCahing;

public interface ICachedQuery<TResponse> : IQuery<TResponse>, ICachedQuery;

public interface ICachedQuery
{
    string CacheKey { get; }

    TimeSpan? Expiration { get; }
}
