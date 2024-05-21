using Moq;
using StackExchange.Redis;

namespace Shared.Infrastructure.Services
{
  [TestClass]
  public class CacheServiceTests
  {
    private Mock<IConnectionMultiplexer> _mockConnectionMultiplexer;
    private Mock<IDatabase> _mockDatabase;
    private CacheService _cacheService;

    [TestInitialize]
    public void Setup()
    {
      _mockConnectionMultiplexer = new Mock<IConnectionMultiplexer>();
      _mockDatabase = new Mock<IDatabase>();
      _mockConnectionMultiplexer
        .Setup(conn => conn.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
        .Returns(_mockDatabase.Object);
      _cacheService = new CacheService(_mockConnectionMultiplexer.Object);
    }

    [TestMethod]
    public void Get_RetrievesStringByKey()
    {
      // Arrange
      var key = "testKey";
      var expectedValue = "testValue";
      _mockDatabase.Setup(db => db.StringGet(key, It.IsAny<CommandFlags>())).Returns(expectedValue);

      // Act
      var result = _cacheService.Get(key);

      // Assert
      Assert.AreEqual(expectedValue, result);
      _mockDatabase.Verify(db => db.StringGet(key, It.IsAny<CommandFlags>()), Times.Once());
    }

    [TestMethod]
    public void Get_RetrievesBytesByKey()
    {
      // Arrange
      var key = "testKey";
      var expectedValue = new byte[] { 1, 2, 3 };
      _mockDatabase.Setup(db => db.StringGet(key, It.IsAny<CommandFlags>())).Returns(expectedValue);

      // Act
      var result = _cacheService.GetBytes(key);

      // Assert
      Assert.AreEqual(expectedValue, result);
      _mockDatabase.Verify(db => db.StringGet(key, It.IsAny<CommandFlags>()), Times.Once());
    }

    [TestMethod]
    public void Remove_DeletesKey()
    {
      // Arrange
      var key = "testKey";

      // Act
      _cacheService.Remove(key);

      // Assert
      _mockDatabase.Verify(db => db.KeyDelete(key, It.IsAny<CommandFlags>()), Times.Once());
    }

    [TestMethod]
    public void AddToList_AddsValueToListAndSetsExpiration()
    {
      // Arrange
      var key = "testList";
      var value = "testValue";
      var expiration = TimeSpan.FromMinutes(5);

      // Act
      _cacheService.AddToList(key, value, expiration);

      // Assert
      _mockDatabase.Verify(
        db => db.ListRightPush(key, value, When.Always, CommandFlags.None),
        Times.Once()
      );
      _mockDatabase.Verify(
        db => db.KeyExpire(key, expiration, It.IsAny<ExpireWhen>(), CommandFlags.None),
        Times.Once()
      );
    }

    [TestMethod]
    public void GetListLength_GetsLengthOfList()
    {
      // Arrange
      var key = "testList";
      var expectedLength = 10L;
      _mockDatabase
        .Setup(db => db.ListLength(key, It.IsAny<CommandFlags>()))
        .Returns(expectedLength);

      // Act
      var result = _cacheService.GetListLength(key);

      // Assert
      Assert.AreEqual(expectedLength, result);
      _mockDatabase.Verify(db => db.ListLength(key, It.IsAny<CommandFlags>()), Times.Once());
    }

    [TestMethod]
    public void Set_SetsStringValueWithExpiration()
    {
      // Arrange
      var key = "testKey";
      var value = "testValue";
      var expiration = TimeSpan.FromMinutes(5);

      // Act
      _cacheService.Set(key, value, expiration);

      // Assert
      _mockDatabase.Verify(
        db =>
          db.StringSet(
            key,
            value,
            expiration,
            It.IsAny<bool>(),
            It.IsAny<When>(),
            CommandFlags.None
          ),
        Times.Once()
      );
    }

    [TestMethod]
    public void Set_SetsStringValueWithoutExpiration()
    {
      // Arrange
      var key = "testKey";
      var value = "testValue";

      // Act
      _cacheService.Set(key, value);

      // Assert
      _mockDatabase.Verify(
        db => db.StringSet(key, value, null, It.IsAny<bool>(), It.IsAny<When>(), CommandFlags.None),
        Times.Once()
      );
    }
  }
}
