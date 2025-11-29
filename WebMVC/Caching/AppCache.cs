using FluentResults;
using Microsoft.Extensions.Caching.Memory;

namespace WebMVC.Caching;

public class AppCache : IAppCache
{
    private readonly IMemoryCache _cache;

    public AppCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<Result<T>> GetOrCreateAsync<T>(
        string cacheKey,
        Func<Task<Result<T>>> factory,
        TimeSpan? slidingWindowExpiration = null,
        TimeSpan? absoluteExpiration = null
    )
    {
        if (!_cache.TryGetValue(cacheKey, out T? cached))
        {
            var res = await factory();
            if (res.IsFailed)
            {
                return res;
            }

            cached = res.Value;
            _cache.Set(
                cacheKey,
                cached,
                new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(slidingWindowExpiration ?? TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(absoluteExpiration ?? TimeSpan.FromSeconds(120))
            );
        }

        return cached == null
            ? Result.Fail("Cache miss and factory returned null.")
            // ^^^ should not happen (services/facades do not return null) ^^^
            : Result.Ok(cached);
    }

    public Task<Result<T>> GetOrCreateAsync<T>(
        string cacheKey,
        Func<Task<T>> factory,
        TimeSpan? slidingWindowExpiration = null,
        TimeSpan? absoluteExpiration = null
    )
    {
        return GetOrCreateAsync(
            cacheKey,
            async () =>
            {
                var value = await factory();
                return Result.Ok(value);
            },
            slidingWindowExpiration,
            absoluteExpiration
        );
    }

    public void Remove(string cacheKey)
    {
        _cache.Remove(cacheKey);
    }
}
