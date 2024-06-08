using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface IAssessmentRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
  {
    public Task<TEntity> AddAsync(RegisterAssessmentApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateAssessmentApplicationResponse entity);
  }
}
