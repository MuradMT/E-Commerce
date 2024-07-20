namespace E_Commerce_Backend.Application.Interfaces.RedisCache;

public interface ICacheableQuery
{
     string CacheKey { get;  }
     double CacheTime { get;  }
}