using FluentResults;

namespace WebMVC.Caching;

/// <summary>
/// Wrapper for IMemoryCache.
/// </summary>
public interface IAppCache
{
    /// <summary>
    /// Gets the object from cache if it exists behind given cacheKey, or
    /// loads (from db) and stores the object returned from factory
    /// (service or facade method) in the cache.
    /// </summary>
    /// <param name="cacheKey">Unique cache key</param>
    /// <param name="factory">A delegate representing some Get method from services or facades</param>
    /// <param name="slidingWindowExpiration">Sliding window timespan of how long the stored object
    /// will remain in the cache.</param>
    /// <param name="absoluteExpiration">Absolute timespan of how long the stored object
    /// will remain in the cache. The object is freed even if the sliding window span goes past the absolute.</param>
    /// <typeparam name="T">Any DTO object (or a collection) returned from the service/facade get methods.</typeparam>
    /// <returns></returns>
    public Task<Result<T>> GetOrCreateAsync<T>(
        string cacheKey,
        Func<Task<Result<T>>> factory,
        TimeSpan? slidingWindowExpiration = null,
        TimeSpan? absoluteExpiration = null
    );

    // because some service/facade methods do not return Result. Always returns Result.OK()
    public Task<Result<T>> GetOrCreateAsync<T>(
        string cacheKey,
        Func<Task<T>> factory,
        TimeSpan? slidingWindowExpiration = null,
        TimeSpan? absoluteExpiration = null
    );

    public void Remove(string cacheKey);
    public void Clear();
}
