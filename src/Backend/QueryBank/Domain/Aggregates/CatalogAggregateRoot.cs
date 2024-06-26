using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Helpers;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Events.Interfaces;

namespace QueryBank.Domain.Aggregates
{
  public class CatalogAggregateRoot(IEvent eventHandler)
    : BaseAggregateRoot(eventHandler),
      ICatalogAggregateRoot
  {
    public Result<RegisterSkillDomainResponse> RegisterSkill(RegisterSkillDomainRequest skillData)
    {
      return RegisterSkillHelper.Execute(skillData);
    }

    public Result<DeleteSkillDomainResponse> DeleteSkill(DeleteSkillDomainRequest dataDeleteRole)
    {
      return DeleteSkillHelper.Execute(dataDeleteRole);
    }

    public Result<UpdateSkillDomainResponse> UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill)
    {
      return UpdateSkillHelper.Execute(dataUpdateSkill);
    }
  }
}
