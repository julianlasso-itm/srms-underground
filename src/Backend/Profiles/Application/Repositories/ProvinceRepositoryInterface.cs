using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories;

public interface IProvinceRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    public new Task<IEnumerable<TEntity>> GetWithPaginationAsync(
        int page,
        int limit,
        string? sort = null,
        string order = "asc",
        string? filter = null,
        string? filterBy = null
    );
    public Task<TEntity> AddAsync(RegisterProvinceApplicationResponse entity);
    public Task<TEntity> UpdateAsync(Guid id, UpdateProvinceApplicationResponse entity);
}
