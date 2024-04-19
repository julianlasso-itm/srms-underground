namespace AccessControl.Application.Responses;

public sealed class GetRolesResponse<TEntity>
    where TEntity : class
{
    public IEnumerable<TEntity> Roles { get; init; }
    public int Total { get; init; }
}
