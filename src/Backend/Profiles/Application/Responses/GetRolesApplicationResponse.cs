namespace Profiles.Application.Responses
{
  public sealed class GetRolesApplicationResponse<TEntity>
    where TEntity : class
  {
    public IEnumerable<TEntity> Roles { get; init; }
    public int Total { get; init; }
  }
}
