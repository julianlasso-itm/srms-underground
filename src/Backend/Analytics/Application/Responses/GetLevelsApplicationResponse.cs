namespace Analytics.Application.Responses
{
  public sealed class GetLevelsApplicationResponse<TEntity>
    where TEntity : class
  {
    public IEnumerable<TEntity> Levels { get; init; }
    public int Total { get; init; }
  }
}
