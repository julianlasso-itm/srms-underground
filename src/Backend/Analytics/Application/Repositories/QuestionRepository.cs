using Analytics.Application.Responses;
using Shared.Application.Interfaces;

namespace Analytics.Application.Repositories;

public interface IQuestionRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public Task<TEntity> AddAsync(RegisterQuestionApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateQuestionApplicationResponse entity);
}
