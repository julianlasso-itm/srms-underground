using AccessControl.Application;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Domain.Aggregates;
using AccessControl.Infrastructure.AntiCorruption;
using AccessControl.Infrastructure.Persistence.Models;
using Shared.Application.Interfaces;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace AccessControl.Infrastructure.Services
{
  public class ApplicationService
  {
    private readonly IApplication<UserModel, RoleModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      IUserRepository<UserModel> userRepository,
      IRoleRepository<RoleModel> roleRepository,
      MessageService messageService,
      ICacheService cacheService,
      IStoreService storeService,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayerService
    )
    {
      _application = new Application<UserModel, RoleModel>(
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetDomainToApplication(),
        messageService,
        cacheService,
        storeService,
        userRepository,
        roleRepository
      )
      {
        AggregateRoot = new SecurityAggregateRoot(eventHandler)
      };
    }

    public IApplication<UserModel, RoleModel> GetApplication()
    {
      return _application;
    }
  }
}
