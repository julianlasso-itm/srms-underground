using Azure.Storage.Blobs;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Services
{
  public class StoreService(BlobServiceClient blobServiceClient) : IStoreService
  {
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;

    public async Task<string> AddAsync(byte[] data, string extension, string containerName)
    {
      var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
      await containerClient.CreateIfNotExistsAsync();
      var fileName = $"SRMS-{Guid.NewGuid()}{extension}";
      var blobClient = containerClient.GetBlobClient(fileName);
      await blobClient.UploadAsync(new MemoryStream(data), overwrite: true);
      return blobClient.Uri.ToString();
    }

    public async Task RemoveAsync(string path, string containerName)
    {
      var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
      await containerClient.CreateIfNotExistsAsync();
      var blobClient = containerClient.GetBlobClient(path);
      await blobClient.DeleteIfExistsAsync();
    }
  }
}
