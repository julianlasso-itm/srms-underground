namespace Shared.Application.Interfaces
{
  public interface ICacheService
  {
    string? Get(string key);
    byte[]? GetBytes(string key);
    void Set(string key, string value);
    void Set(string key, byte[] value);
    void Remove(string key);
  }
}
