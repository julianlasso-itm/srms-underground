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
    private readonly Application<UserModel, RoleModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      IUserRepository<UserModel> userRepository,
      IRoleRepository<RoleModel> roleRepository,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayerService
    )
    {
      _application = new Application<UserModel, RoleModel>(
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetDomainToApplication(),
        userRepository,
        roleRepository
      )
      {
        AggregateRoot = new SecurityAggregateRoot(eventHandler)
      };
    }

    public Application<UserModel, RoleModel> GetApplication()
    {
      return _application;
    }
  }
}
