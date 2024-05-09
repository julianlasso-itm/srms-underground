using Azure.Storage.Blobs;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Services
{
  public class StoreService : IStoreService
  {
    private readonly string _storeUrl =
      "DefaultEndpointsProtocol=https;AccountName=orderszulu2024;AccountKey=aUBtiF7GTURebDNoae/2mn3BxISYUe5GzpldozWo96SI07nPU/M3XUf3JjUdtdlX/nTsJ48/8EkM+AStm/YdLA==;EndpointSuffix=core.windows.net";

    public async Task<string> AddAsync(byte[] data, string extension, string containerName)
    {
      // var client = new BlobServiceClient(_storeUrl);
      // var containerClient = client.GetBlobContainerClient(containerName);
      // await containerClient.CreateIfNotExistsAsync();
      // var fileName = $"SRMS-{Guid.NewGuid()}{extension}";
      // var blobClient = containerClient.GetBlobClient(fileName);
      // await blobClient.UploadAsync(new MemoryStream(data), true);
      // return blobClient.Uri.ToString();
      return "https://orderszulu2024.blob.core.windows.net/avatars/SRMS-" + Guid.NewGuid() + extension;
    }

    public async Task RemoveAsync(string path, string containerName)
    {
      var client = new BlobServiceClient(_storeUrl);
      var containerClient = client.GetBlobContainerClient(containerName);
      await containerClient.CreateIfNotExistsAsync();
      var blobClient = containerClient.GetBlobClient(path);
      await blobClient.DeleteIfExistsAsync();
    }
  }
}
