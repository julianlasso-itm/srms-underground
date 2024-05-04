using AccessControl.Application;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.AntiCorruption;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace AccessControl.Infrastructure.Services
{
  public class ApplicationService
  {
    private readonly Application<RoleModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      IRoleRepository<RoleModel> roleRepository,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayer
    )
    {
      _application = new Application<RoleModel>(
        antiCorruptionLayer.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayer.GetAntiCorruptionLayer().GetDomainToApplication(),
        roleRepository
      )
      {
        AggregateRoot = new SecurityAggregateRoot(eventHandler)
      };
    }

    public Application<RoleModel> GetApplication()
    {
      return _application;
    }
  }
}
