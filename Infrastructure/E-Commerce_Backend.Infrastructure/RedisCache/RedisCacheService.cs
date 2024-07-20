using System.Text.Json;
using E_Commerce_Backend.Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace E_Commerce_Backend.Infrastructure.RedisCache;

public class RedisCacheService:IRedisCacheService
{
    private readonly ConnectionMultiplexer _redisConnection;
    private readonly IDatabase _database;
    private readonly RedisCacheSettings _settings;

    public RedisCacheService(IOptions<RedisCacheSettings> options)
    {
        _settings = options.Value;
        var opt = ConfigurationOptions.Parse(_settings.ConnectionString);
        _redisConnection = ConnectionMultiplexer.Connect(opt);
        _database = _redisConnection.GetDatabase();
    }
    public async Task<T> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.HasValue) JsonSerializer.Deserialize<T>(value);
        return default;
    }

    public async Task SetAsync<T>(string key, T value, DateTime? expirationDate = null)
    {
        TimeSpan timeUnitExpiration = expirationDate.Value - DateTime.Now;
        await _database.StringSetAsync(key, JsonSerializer.Serialize(value),timeUnitExpiration);
    }
}