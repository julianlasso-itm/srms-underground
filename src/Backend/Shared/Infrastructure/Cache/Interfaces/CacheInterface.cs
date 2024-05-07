namespace Shared.Infrastructure.Cache
{
  public interface ICache
  {
    string? Get(string key);
    Type[]? Get<Type>(string key);
    void Set(string key, string value);
    void Set(string key, byte[] value);
    void Remove(string key);
  }
}
