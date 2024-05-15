using System.Text;
using Shared.Application.Interfaces;
using StackExchange.Redis;

namespace Shared.Infrastructure.Services
{
  public class CacheService : ICacheService
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

    public byte[]? GetBytes(string key)
    {
      return _database.StringGet(key);
    }

    public void Set(string key, string value, TimeSpan? expiration = null)
    {
      _database.StringSet(key, value, expiration);
    }

    public void Set(string key, byte[] value, TimeSpan? expiration = null)
    {
      _database.StringSet(key, value, expiration);
    }

    public void Remove(string key)
    {
      _database.KeyDelete(key);
    }

    public void AddToList(string key, string value, TimeSpan? expiration = null)
    {
      _database.ListRightPush(key, value);
      if (expiration != null)
      {
        _database.KeyExpire(key, expiration);
      }
    }

    public long GetListLength(string key)
    {
      return _database.ListLength(key);
    }
  }
}
