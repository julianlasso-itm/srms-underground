using QueryBank.Application;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates;
using QueryBank.Infrastructure.AntiCorruption;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;
using Shared.Infrastructure.Services;

namespace QueryBank.Infrastructure.Services
{
  public class ApplicationService(
    IServiceProvider serviceProvider,
    SharedEventHandler eventHandler,
    ISkillRepository<SkillModel> skillRepository
    )
  {
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly SharedEventHandler _eventHandler = eventHandler;
    private readonly ISkillRepository<SkillModel> _skillRepository = skillRepository;

    public Application<SkillModel> GetApplication()
    {
      using (var scope = _serviceProvider.CreateScope())
      {
        var antiCorruptionLayerService = scope.ServiceProvider.GetRequiredService<
          AntiCorruptionLayerService<AntiCorruptionLayer>
        >();
        var antiCorruptionLayer = antiCorruptionLayerService.GetAntiCorruptionLayer();

        return new Application<SkillModel>(
          antiCorruptionLayer.GetApplicationToDomain(),
          antiCorruptionLayer.GetDomainToApplication(),
          _skillRepository
        )
        {
          AggregateRoot = new CatalogAggregateRoot(_eventHandler)
        };
      }
    }
  }
}
