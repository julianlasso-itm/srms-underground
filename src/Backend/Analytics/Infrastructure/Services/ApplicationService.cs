using Analytics.Application;
using Analytics.Application.Repositories;
using Analytics.Domain.Aggregates;
using Analytics.Infrastructure.AntiCorruption;
using Analytics.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace Analytics.Infrastructure.Services
{
  public class ApplicationService
  {
    private readonly Application<LevelModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      ILevelRepository<LevelModel> levelRepository,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayerService
    )
    {
      _application = new Application<LevelModel>(
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetDomainToApplication(),
        levelRepository
      )
      {
        AggregateRoot = new AggregateRoot(eventHandler)
      };
    }

    public Application<LevelModel> GetApplication()
    {
      return _application;
    }
  }
}
