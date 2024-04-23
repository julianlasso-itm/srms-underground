using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories;

public interface IProvinceRepository<TEntity> : IRepository<TEntity>
    where TEntity : class { }
