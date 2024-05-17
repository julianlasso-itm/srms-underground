using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteProfessionalHelper
    : BaseHelper,
      IHelper<DeleteProfessionalDomainRequest, DeleteProfessionalDomainResponse>
  {
    public static DeleteProfessionalDomainResponse Execute(DeleteProfessionalDomainRequest request)
    {
      var record = GetProfessionalRecord(request);
      ValidateRecordFields(record);
      return new DeleteProfessionalDomainResponse { ProfessionalId = record.ProfessionalId.Value };
    }

    private static ProfessionalRecord GetProfessionalRecord(DeleteProfessionalDomainRequest request)
    {
      var id = new ProfessionalIdValueObject(request.ProfessionalId);
      return new ProfessionalRecord { ProfessionalId = id };
    }
  }
}
