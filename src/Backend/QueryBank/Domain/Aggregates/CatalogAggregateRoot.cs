using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Helpers;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace QueryBank.Domain.Aggregates
{
  public class CatalogAggregateRoot(IEvent eventHandler)
    : BaseAggregateRoot(eventHandler),
      ICatalogAggregateRoot
  {
    public RegisterSkillDomainResponse RegisterSkill(RegisterSkillDomainRequest skillData)
    {
      return RegisterSkillHelper.Execute(skillData);
    }

    public DeleteSkillDomainResponse DeleteSkill(DeleteSkillDomainRequest dataDeleteRole)
    {
      return DeleteSkillHelper.Execute(dataDeleteRole);
    }

    public UpdateSkillDomainResponse UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill)
    {
      return UpdateSkillHelper.Execute(dataUpdateSkill);
    }
  }
}
