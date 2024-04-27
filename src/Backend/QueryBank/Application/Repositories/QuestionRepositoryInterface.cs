using QueryBank.Application.Responses;
using Shared.Application.Interfaces;

namespace QueryBank.Application.Repositories
{
    public interface IQuestionRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public Task<TEntity> AddAsync(RegisterQuestionApplicationResponse entity);

        public Task<TEntity> UpdateAsync(Guid id, UpdateQuestionApplicationResponse entity);

    }
}
