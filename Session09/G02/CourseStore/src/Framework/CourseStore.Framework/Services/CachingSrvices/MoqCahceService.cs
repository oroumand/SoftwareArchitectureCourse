using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Framework.Services.CachingSrvices;
public class MoqCahceService : ICacheService
{
    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        return default;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {

    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {

    }
}
