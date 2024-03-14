namespace Shared.Application.Interfaces;

public interface IRepository<Entity> where Entity : class
{
    Task<Entity> AddAsync(Entity entity);
    Task<Entity> UpdateAsync(Entity entity);
    Task<Entity> DeleteAsync(Entity entity);
    Task<Entity> GetByIdAsync(Guid id);
    Task<IEnumerable<Entity>> GetAllAsync();
}
