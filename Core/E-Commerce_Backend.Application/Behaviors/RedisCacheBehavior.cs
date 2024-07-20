using E_Commerce_Backend.Application.Interfaces.RedisCache;
using MediatR;

namespace E_Commerce_Backend.Application.Behaviors;

public class RedisCacheBehavior<TRequest,TResponse>(IRedisCacheService _redisCacheService):IPipelineBehavior<TRequest,TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is ICacheableQuery query)
        {
            var cacheKey = query.CacheKey;
            var cacheTime = query.CacheTime;

            var cachedData = await _redisCacheService.GetAsync<TResponse>(cacheKey);
            if (cachedData is not null) return cachedData;

            var response = await next();
            if (response is not null)
                await _redisCacheService.SetAsync(cacheKey, response,DateTime.Now.AddMinutes(cacheTime));
            return response;
        }

        return await next();
    }
}