namespace Analytics.Application.Responses;

public sealed class GetQuestionApplicationResponse<TEntity>
    where TEntity : class
{
    public IEnumerable<TEntity> Questions { get; init; }
    public int Total { get; init; }
}
