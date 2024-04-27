using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
    public interface IProfessionalRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> AddAsync(RegisterProfessionalApplicationResponse entity);

        public Task<TEntity> UpdateAsync(Guid id, UpdateProfessionalApplicationResponse entity);
    }
}
