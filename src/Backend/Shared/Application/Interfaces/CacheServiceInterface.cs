namespace Shared.Application.Interfaces
{
  public interface ICacheService
  {
    string? Get(string key);
    byte[]? GetBytes(string key);
    void Set(string key, string value, TimeSpan? expiration = null);
    void Set(string key, byte[] value, TimeSpan? expiration = null);
    void Remove(string key);
  }
}
