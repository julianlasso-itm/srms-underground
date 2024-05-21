using Moq;
using StackExchange.Redis;

namespace Shared.Infrastructure.Events
{
  [TestClass]
  public class SharedEventHandlerTests
  {
    [TestMethod]
    public void Emit_PublishesDataToCorrectChannel()
    {
      // Arrange
      var mockConnection = new Mock<IConnectionMultiplexer>();
      var mockSubscriber = new Mock<ISubscriber>();
      mockConnection.Setup(x => x.GetSubscriber(null)).Returns(mockSubscriber.Object);

      var handler = new SharedEventHandler(mockConnection.Object);
      var channel = "testChannel";
      var data = "testData";

      // Act
      handler.Emit(channel, data);

      // Assert
      mockSubscriber.Verify(
        sub =>
          sub.Publish(
            It.Is<RedisChannel>(channel => channel.ToString() == channel),
            data,
            It.IsAny<CommandFlags>()
          ),
        Times.Once()
      );
    }
  }
}
