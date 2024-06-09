using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
  public interface IPodiumRepository<TEntity> : IRepository<TEntity>
    where TEntity : class { }
}
