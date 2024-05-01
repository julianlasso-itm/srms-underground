using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers
{
  internal abstract class DeleteSkillHelper
    : BaseHelper,
      IHelper<DeleteSkillDomainRequest, DeleteSkillDomainResponse>
  {
    public static DeleteSkillDomainResponse Execute(DeleteSkillDomainRequest request)
    {
      var @struct = GetSkillStruct(request);
      ValidateStructureFields(@struct);
      return new DeleteSkillDomainResponse { SkillId = @struct.SkillId.Value };
    }

    private static SkillStruct GetSkillStruct(DeleteSkillDomainRequest request)
    {
      var id = new SkillIdValueObject(request.SkillId);
      return new SkillStruct { SkillId = id };
    }
  }
}
