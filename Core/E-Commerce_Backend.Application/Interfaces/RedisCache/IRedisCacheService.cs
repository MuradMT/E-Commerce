namespace E_Commerce_Backend.Application.Interfaces.RedisCache;

public interface IRedisCacheService
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, DateTime? expirationDate = null);
}