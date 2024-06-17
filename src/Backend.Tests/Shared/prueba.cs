using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Shared.Infrastructure.Persistence.Repositories;

public class MyEntityTests
{
  private Mock<DbSet<TEntity>> MockDbSet<TEntity>(List<TEntity> sourceList)
    where TEntity : class
  {
    var data = sourceList.AsQueryable();
    var mockSet = new Mock<DbSet<TEntity>>();

    mockSet
      .As<IQueryable<TEntity>>()
      .Setup(m => m.Provider)
      .Returns(new TestAsyncQueryProvider<TEntity>(data.Provider));
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

    mockSet
      .As<IAsyncEnumerable<TEntity>>()
      .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
      .Returns(new TestAsyncEnumerator<TEntity>(data.GetEnumerator()));

    return mockSet;
  }
}

public static class TestingUtilities
{
  public static Mock<DbSet<TEntity>> MockDbSet<TEntity>(List<TEntity> sourceList)
    where TEntity : class
  {
    var data = sourceList.AsQueryable();
    var mockSet = new Mock<DbSet<TEntity>>();

    mockSet
      .As<IQueryable<TEntity>>()
      .Setup(m => m.Provider)
      .Returns(new TestAsyncQueryProvider<TEntity>(data.Provider));
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
    mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

    mockSet
      .As<IAsyncEnumerable<TEntity>>()
      .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
      .Returns(new TestAsyncEnumerator<TEntity>(data.GetEnumerator()));

    return mockSet;
  }
}

internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
{
  private readonly IQueryProvider _inner;

  internal TestAsyncQueryProvider(IQueryProvider inner)
  {
    _inner = inner;
  }

  public IQueryable CreateQuery(Expression expression)
  {
    return new TestAsyncEnumerable<TEntity>(expression);
  }

  public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
  {
    return new TestAsyncEnumerable<TElement>(expression);
  }

  public object Execute(Expression expression)
  {
    return _inner.Execute(expression)!;
  }

  public TResult Execute<TResult>(Expression expression)
  {
    return _inner.Execute<TResult>(expression);
  }

  public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
  {
    return new TestAsyncEnumerable<TResult>(expression);
  }

  public Task<TResult> ExecuteAsync<TResult>(
    Expression expression,
    CancellationToken cancellationToken
  )
  {
    return Task.FromResult(Execute<TResult>(expression));
  }

  TResult IAsyncQueryProvider.ExecuteAsync<TResult>(
    Expression expression,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }
}

internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
  public TestAsyncEnumerable(IEnumerable<T> enumerable)
    : base(enumerable) { }

  public TestAsyncEnumerable(Expression expression)
    : base(expression) { }

  public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
  {
    return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
  }
}

internal class TestAsyncEnumerator<T>(IEnumerator<T> inner) : IAsyncEnumerator<T>
{
  private readonly IEnumerator<T> _inner = inner;

  public T Current => _inner.Current;

  public ValueTask<bool> MoveNextAsync()
  {
    return ValueTask.FromResult(_inner.MoveNext());
  }

  public ValueTask DisposeAsync()
  {
    _inner.Dispose();
    return ValueTask.CompletedTask;
  }
}

namespace Shared.Tests.Infrastructure.Persistence.Repositories
{
  [TestClass]
  public class BaseRepositoryTests
  {
    [TestMethod]
    public async Task GetFirstAsync_ReturnsEntity_WhenEntityExists()
    {
      // Arrange
      var mockContext = new Mock<DbContext>();
      var testData = new List<TestEntity>
      {
        new TestEntity { Id = Guid.NewGuid() },
        new TestEntity { Id = Guid.NewGuid() }
      };
      var mockSet = TestingUtilities.MockDbSet(testData);
      mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockSet.Object);
      var repository = new TestRepository(mockContext.Object);

      // Act
      var result = await repository.GetFirstAsync(e => e.Id == testData[0].Id);

      // Assert
      Assert.AreEqual(
        testData[0],
        result,
        "The returned entity should match the first entity in the test data."
      );
    }

    [TestMethod]
    public async Task GetFirstAsync_ThrowsException_WhenNoEntityFound()
    {
      // Arrange
      var mockContext = new Mock<DbContext>();
      var testData = new List<TestEntity>(); // No entities in the DbSet
      var mockSet = TestingUtilities.MockDbSet(testData);
      mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockSet.Object);
      var repository = new TestRepository(mockContext.Object);

      // Act & Assert
      await Assert.ThrowsExceptionAsync<Exception>(
        () => repository.GetFirstAsync(e => e.Id == Guid.NewGuid()),
        "Should throw an exception if no entity is found."
      );
    }

    public class TestEntity
    {
      public Guid Id { get; set; }
    }

    public class TestRepository(DbContext context) : BaseRepository<TestEntity>(context) { }
  }
}
