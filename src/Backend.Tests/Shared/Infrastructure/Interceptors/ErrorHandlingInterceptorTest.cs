using System.Net;
using Grpc.Core;
using Grpc.Core.Testing;
using Moq;
using Shared.Domain.Exceptions;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace Shared.Infrastructure.Interceptors
{
  [TestClass]
  public class ErrorHandlingInterceptorTests
  {
    private Mock<UnaryServerMethod<object, object>> _continuation;
    private ServerCallContext _context;
    private ErrorHandlingInterceptor _interceptor;

    [TestInitialize]
    public void Setup()
    {
      _continuation = new Mock<UnaryServerMethod<object, object>>();
      _context = TestServerCallContext.Create(
        "method",
        "host",
        DateTime.UtcNow.AddSeconds(30),
        [],
        CancellationToken.None,
        "peer",
        null,
        null,
        headers => Task.CompletedTask,
        () => new WriteOptions(),
        writeOptions => { }
      );

      _interceptor = new ErrorHandlingInterceptor();
    }

    [TestMethod]
    public async Task Should_Continue_When_NoException()
    {
      // Arrange
      var expectedResponse = new object();
      _continuation
        .Setup(c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()))
        .ReturnsAsync(expectedResponse);

      // Act
      var result = await _interceptor.UnaryServerHandler(
        new object(),
        _context,
        _continuation.Object
      );

      // Assert
      Assert.AreEqual(expectedResponse, result);
    }

    [TestMethod]
    public async Task Should_ThrowRpcException_When_DomainExceptionThrown()
    {
      // Arrange
      var domainException = new DomainException("Test error", [new("Field", "Error message")]);
      _continuation
        .Setup(c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()))
        .ThrowsAsync(domainException);

      // Act and Assert
      var exception = await Assert.ThrowsExceptionAsync<RpcException>(
        () => _interceptor.UnaryServerHandler(new object(), _context, _continuation.Object)
      );

      // Assert
      Assert.IsTrue(exception.Status.Detail.Contains("Test error"));
      Assert.IsTrue(exception.Status.Detail.Contains("Field"));
      Assert.IsTrue(exception.Status.Detail.Contains("Error message"));
    }

    [TestMethod]
    public async Task Should_ThrowRpcException_When_ApplicationExceptionThrown()
    {
      // Arrange
      var applicationException = new ApplicationException("Test error", HttpStatusCode.NotFound);
      _continuation
        .Setup(c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()))
        .ThrowsAsync(applicationException);

      // Act and Assert
      var exception = await Assert.ThrowsExceptionAsync<RpcException>(
        () => _interceptor.UnaryServerHandler(new object(), _context, _continuation.Object)
      );

      // Assert
      Assert.IsTrue(exception.Status.Detail.Contains("Test error"));
    }

    [TestMethod]
    public async Task Should_ThrowRpcException_When_GeneralExceptionThrown()
    {
      // Arrange
      var exception = new Exception("General error");
      _continuation
        .Setup(c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()))
        .ThrowsAsync(exception);

      // Act and Assert
      var rpcException = await Assert.ThrowsExceptionAsync<RpcException>(
        () => _interceptor.UnaryServerHandler(new object(), _context, _continuation.Object)
      );

      // Assert
      Assert.AreEqual(StatusCode.Internal, rpcException.Status.StatusCode);
      Assert.AreEqual("General error", rpcException.Status.Detail);
    }

    [TestMethod]
    public async Task Should_ReThrow_RpcException_When_RpcExceptionThrown()
    {
      // Arrange
      var rpcException = new RpcException(
        new Status(StatusCode.Unavailable, "Service unavailable")
      );
      _continuation
        .Setup(c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()))
        .ThrowsAsync(rpcException);

      // Act & Assert
      var thrownException = await Assert.ThrowsExceptionAsync<RpcException>(
        () => _interceptor.UnaryServerHandler(new object(), _context, _continuation.Object)
      );

      // Assert
      Assert.AreEqual(rpcException.Status.StatusCode, thrownException.Status.StatusCode);
      Assert.AreEqual("Service unavailable", thrownException.Status.Detail);
      _continuation.Verify(
        c => c.Invoke(It.IsAny<object>(), It.IsAny<ServerCallContext>()),
        Times.Once
      );
    }
  }
}
