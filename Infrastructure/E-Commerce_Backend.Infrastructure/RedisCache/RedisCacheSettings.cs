namespace E_Commerce_Backend.Infrastructure.RedisCache;

public class RedisCacheSettings
{
    //You can manage Redis with Redis Insight
    public string ConnectionString { get; set; }
    public string InstanceName { get; set; }
}