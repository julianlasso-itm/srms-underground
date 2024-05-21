namespace Shared.Infrastructure.Services
{
  [TestClass]
  public class AntiCorruptionLayerServiceTests
  {
    [TestMethod]
    public void AntiCorruptionLayerService_Constructor_ShouldCreateInstance()
    {
      // Arrange & Act
      var service = new AntiCorruptionLayerService<DummyAntiCorruptionLayer>();

      // Assert
      Assert.IsNotNull(
        service.GetAntiCorruptionLayer(),
        "The AntiCorruptionLayer instance should not be null."
      );
    }

    [TestMethod]
    public void GetAntiCorruptionLayer_ShouldReturnSameInstance()
    {
      // Arrange
      var service = new AntiCorruptionLayerService<DummyAntiCorruptionLayer>();
      var expectedInstance = service.GetAntiCorruptionLayer();

      // Act
      var actualInstance = service.GetAntiCorruptionLayer();

      // Assert
      Assert.AreEqual(
        expectedInstance,
        actualInstance,
        "GetAntiCorruptionLayer should return the same instance."
      );
    }
  }

  // Dummy class to act as TAntiCorruptionLayer
  public class DummyAntiCorruptionLayer { }
}
