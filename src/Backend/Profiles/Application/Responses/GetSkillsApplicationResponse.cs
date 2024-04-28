namespace Profiles.Application.Responses
{
    public class GetSkillsApplicationResponse<TEntity>
        where TEntity : class
    {
        public IEnumerable<TEntity> Skills { get; init; }
        public int Total { get; init; }
    }
}
