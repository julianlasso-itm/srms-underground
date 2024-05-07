using StackExchange.Redis;

namespace Shared.Infrastructure.Cache
{
  public class CacheService : ICache
  {
    private readonly ConnectionMultiplexer _cache;
    private readonly IDatabase _database;

    public CacheService(string connectionString = "localhost:6379")
    {
      _cache = ConnectionMultiplexer.Connect(connectionString);
      _database = _cache.GetDatabase();
    }

    public string? Get(string key)
    {
      return _database.StringGet(key);
    }

    public Type[]? Get<Type>(string key)
    {
      return [(Type)(object)_database.StringGet(key)];
    }

    public void Set(string key, string value)
    {
      _database.StringSet(key, value);
    }

    public void Set(string key, byte[] value)
    {
      _database.StringSet(key, value);
    }

    public void Remove(string key)
    {
      _database.KeyDelete(key);
    }
  }
}
