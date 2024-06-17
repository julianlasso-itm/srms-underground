using Shared.Domain.ValueObjects;

namespace Shared.Domain.Exceptions
{
  [TestClass]
  public class DomainExceptionTests
  {
    [TestMethod]
    public void DomainException_Sets_Message_And_DomainErrors()
    {
      // Arrange
      var expectedMessage = "Test exception message";
      var expectedErrors = new List<ErrorValueObject>
      {
        new("Field1", "Error message 1"),
        new("Field2", "Error message 2")
      };

      // Act
      var exception = new DomainException(expectedMessage, expectedErrors);

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message, "The message was not set correctly.");
      CollectionAssert.AreEqual(
        expectedErrors,
        exception.DomainErrors,
        "The errors were not set correctly."
      );
    }

    [TestMethod]
    public void DomainException_WithInnerException_Sets_Message_Errors_And_InnerException()
    {
      // Arrange
      var expectedMessage = "Test exception message";
      var expectedErrors = new List<ErrorValueObject>
      {
        new("Field1", "Error message 1"),
        new("Field2", "Error message 2")
      };
      Exception expectedInnerException = new InvalidOperationException("Inner exception message");

      // Act
      var exception = new DomainException(expectedMessage, expectedErrors, expectedInnerException);

      // Assert
      Assert.AreEqual(expectedMessage, exception.Message, "The message was not set correctly.");
      CollectionAssert.AreEqual(
        expectedErrors,
        exception.DomainErrors,
        "The domain errors were not set correctly."
      );
      Assert.AreEqual(
        expectedInnerException,
        exception.InnerException,
        "The inner exception was not set correctly."
      );
    }
  }
}
