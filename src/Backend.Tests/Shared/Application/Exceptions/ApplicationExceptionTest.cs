using System.Net;

namespace Shared.Application.Exceptions
{
  [TestClass]
  public class ApplicationExceptionTests
  {
    [TestMethod]
    public void Constructor_WithOnlyMessage_SetsMessageAndDefaultStatusCode()
    {
      // Arrange
      var expectedMessage = "An error occurred";

      // Act
      var exception = new ApplicationException(expectedMessage);

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message);
      Assert.AreEqual(HttpStatusCode.InternalServerError, exception.StatusCode);
    }

    [TestMethod]
    public void Constructor_WithMessageAndInnerException_SetsMessageInnerExceptionAndDefaultStatusCode()
    {
      // Arrange
      var expectedMessage = "An error occurred";
      var expectedInnerException = new Exception("Inner exception message");

      // Act
      var exception = new ApplicationException(expectedMessage, expectedInnerException);

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message);
      Assert.AreEqual(expectedInnerException, exception.InnerException);
      Assert.AreEqual(HttpStatusCode.InternalServerError, exception.StatusCode);
    }

    [TestMethod]
    public void Constructor_WithMessageAndStatusCode_SetsMessageAndStatusCode()
    {
      // Arrange
      var expectedMessage = "An error occurred";
      var expectedStatusCode = HttpStatusCode.BadRequest;

      // Act
      var exception = new ApplicationException(expectedMessage, expectedStatusCode);

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message);
      Assert.AreEqual(expectedStatusCode, exception.StatusCode);
    }

    [TestMethod]
    public void Constructor_WithMessageStatusCodeAndInnerException_SetsAllProperties()
    {
      // Arrange
      var expectedMessage = "An error occurred";
      var expectedStatusCode = HttpStatusCode.NotFound;
      var expectedInnerException = new Exception("Inner exception message");

      // Act
      var exception = new ApplicationException(
        expectedMessage,
        expectedStatusCode,
        expectedInnerException
      );

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message);
      Assert.AreEqual(expectedStatusCode, exception.StatusCode);
      Assert.AreEqual(expectedInnerException, exception.InnerException);
    }
  }
}
