namespace Profiles.Application.Responses
{
  public sealed class GetProvincesApplicationResponse<TEntity>
    where TEntity : class
  {
    public IEnumerable<TEntity> Provinces { get; init; }
    public int Total { get; init; }
  }
}
