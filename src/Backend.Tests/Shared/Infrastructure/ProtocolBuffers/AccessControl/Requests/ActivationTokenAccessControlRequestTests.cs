using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace Shared.Tests.Infrastructure.ProtocolBuffers.AccessControl.Requests
{
  [TestClass]
  public class ActivationTokenAccessControlRequestTests
  {
    [TestMethod]
    public void ActivationTokenAccessControlRequest_Should_InitializeWithActivationToken()
    {
      // Arrange
      var activationToken = "testToken";

      // Act
      var request = new ActivationTokenAccessControlRequest { ActivationToken = activationToken };

      // Assert
      Assert.AreEqual(activationToken, request.ActivationToken);
    }
  }
}
