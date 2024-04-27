namespace QueryBank.Application.Responses
{
    public class GetQuestionsApplicationResponse<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Questions { get; init; }
        public int Total { get; init; }
    }
}
