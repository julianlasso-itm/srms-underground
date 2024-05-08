namespace Shared.Application.Interfaces
{
  public interface IStoreService {
    public string AddAsync(byte[] data);
    public void RemoveAsync(string path);
  }
}
