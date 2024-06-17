namespace Shared.Domain.ValueObjects
{
  [TestClass]
  public class ErrorValueObjectTests
  {
    [TestMethod]
    public void Constructor_Assigns_Field_And_Message()
    {
      // Arrange
      var expectedField = "Username";
      var expectedMessage = "Must be at least 3 characters long.";

      // Act
      var error = new ErrorValueObject(expectedField, expectedMessage);

      // Assert
      Assert.AreEqual(expectedField, error.Field, "Field was not correctly assigned.");
      Assert.AreEqual(expectedMessage, error.Message, "Message was not correctly assigned.");
    }
  }
}
