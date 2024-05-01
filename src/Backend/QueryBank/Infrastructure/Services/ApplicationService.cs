using QueryBank.Application;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace QueryBank.Infrastructure.Services
{
  public class ApplicationService
  {
    private readonly Application<SkillModel> _application;

    public ApplicationService(
      SharedEventHandler eventHandler,
      ISkillRepository<SkillModel> skillRepository
    )
    {
      _application = new Application<SkillModel>(skillRepository)
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
