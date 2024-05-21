using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Moq;
using Shared.Infrastructure.Services;

namespace Shared.Tests.Infrastructure.Services
{
  [TestClass]
  public class StoreServiceTests
  {
    private Mock<BlobServiceClient> _mockBlobServiceClient;
    private Mock<BlobContainerClient> _mockBlobContainerClient;
    private Mock<BlobClient> _mockBlobClient;
    private StoreService _storeService;

    [TestInitialize]
    public void Setup()
    {
      _mockBlobServiceClient = new Mock<BlobServiceClient>();
      _mockBlobContainerClient = new Mock<BlobContainerClient>();
      _mockBlobClient = new Mock<BlobClient>();

      _mockBlobServiceClient
        .Setup(x => x.GetBlobContainerClient(It.IsAny<string>()))
        .Returns(_mockBlobContainerClient.Object);

      _mockBlobContainerClient
        .Setup(x => x.GetBlobClient(It.IsAny<string>()))
        .Returns(_mockBlobClient.Object);

      _storeService = new StoreService(_mockBlobServiceClient.Object);
    }

    [TestMethod]
    public async Task AddAsync_UploadsDataAndReturnsUri()
    {
      // Arrange
      var data = new byte[] { 1, 2, 3 };
      var extension = ".txt";
      var containerName = "testContainer";
      var expectedUri = new Uri("https://example.com/blob");

      _mockBlobClient
        .Setup(x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()))
        .ReturnsAsync(new Mock<Response<BlobContentInfo>>().Object);
      _mockBlobClient.Setup(x => x.Uri).Returns(expectedUri);

      _mockBlobContainerClient
        .Setup(x =>
          x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>())
        )
        .ReturnsAsync(new Mock<Response<BlobContainerInfo>>().Object);

      // Act
      var result = await _storeService.AddAsync(data, extension, containerName);

      // Assert
      Assert.AreEqual(expectedUri.ToString(), result);
      _mockBlobContainerClient.Verify(
        x =>
          x.CreateIfNotExistsAsync(
            PublicAccessType.None,
            null,
            null,
            It.IsAny<CancellationToken>()
          ),
        Times.Once
      );
      _mockBlobContainerClient.Verify(x => x.GetBlobClient(It.IsAny<string>()), Times.Once);
      _mockBlobClient.Verify(
        x => x.UploadAsync(It.IsAny<Stream>(), true, It.IsAny<CancellationToken>()),
        Times.Once
      );
    }

    [TestMethod]
    public async Task RemoveAsync_DeletesBlob()
    {
      // Arrange
      var path = "testBlob";
      var containerName = "testContainer";

      _mockBlobClient
        .Setup(x =>
          x.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null, It.IsAny<CancellationToken>())
        )
        .ReturnsAsync(new Mock<Response<bool>>().Object);

      _mockBlobContainerClient
        .Setup(x =>
          x.CreateIfNotExistsAsync(PublicAccessType.None, null, null, It.IsAny<CancellationToken>())
        )
        .ReturnsAsync(new Mock<Response<BlobContainerInfo>>().Object);

      // Act
      await _storeService.RemoveAsync(path, containerName);

      // Assert
      _mockBlobContainerClient.Verify(
        x =>
          x.CreateIfNotExistsAsync(
            PublicAccessType.None,
            null,
            null,
            It.IsAny<CancellationToken>()
          ),
        Times.Once
      );
      _mockBlobContainerClient.Verify(x => x.GetBlobClient(path), Times.Once);
      _mockBlobClient.Verify(
        x => x.DeleteIfExistsAsync(DeleteSnapshotsOption.None, null, It.IsAny<CancellationToken>()),
        Times.Once
      );
    }
  }
}
