using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using Shared.Common;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Interfaces
{
  public interface ICatalogAggregateRoot : IAggregateRoot
  {
    public Result<DeleteSkillDomainResponse> DeleteSkill(DeleteSkillDomainRequest dataDeleteSkill);
    public Result<RegisterSkillDomainResponse> RegisterSkill(RegisterSkillDomainRequest skillData);
    public Result<UpdateSkillDomainResponse> UpdateSkill(UpdateSkillDomainRequest dataUpdateSkill);
  }
}
