using QueryBank.Application;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates;
using QueryBank.Infrastructure.AntiCorruption;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace QueryBank.Infrastructure.Services
{
  public class ApplicationService
  {
    private readonly Application<SkillModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      ISkillRepository<SkillModel> skillRepository,
      AntiCorruptionLayerService<AntiCorruptionLayer> antiCorruptionLayerService
    )
    {
      _application = new Application<SkillModel>(
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetApplicationToDomain(),
        antiCorruptionLayerService.GetAntiCorruptionLayer().GetDomainToApplication(),
        skillRepository
      )
      {
        AggregateRoot = new CatalogAggregateRoot(eventHandler)
      };
    }

    public Application<SkillModel> GetApplication()
    {
      return _application;
    }
  }
}
