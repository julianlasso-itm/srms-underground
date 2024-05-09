namespace Shared.Application.Interfaces
{
  public interface IStoreService
  {
    public Task<string> AddAsync(byte[] data, string extension, string containerName);
    public Task RemoveAsync(string path, string containerName);

    async Task<string> EditFileAsync(
      byte[] data,
      string extension,
      string path,
      string containerName
    )
    {
      if (path is not null)
      {
        await RemoveAsync(path, containerName);
      }
      return await AddAsync(data, extension, containerName);
    }
  }
}
