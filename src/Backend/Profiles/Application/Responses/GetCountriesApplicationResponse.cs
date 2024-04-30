namespace Profiles.Application.Responses
{
  public sealed class GetCountriesApplicationResponse<TEntity>
    where TEntity : class
  {
    public IEnumerable<TEntity> Countries { get; init; }
    public int Total { get; init; }
  }
}
