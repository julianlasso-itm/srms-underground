namespace Profiles.Application.Responses;

public sealed class GetCitiesApplicationResponse<TEntity>
    where TEntity : class
{
    public IEnumerable<TEntity> Cities { get; init; }
    public int Total { get; init; }
}
