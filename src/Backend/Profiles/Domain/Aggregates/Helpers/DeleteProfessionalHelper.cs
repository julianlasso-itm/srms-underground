using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class DeleteProfessionalHelper
    : BaseHelper,
      IHelper<DeleteProfessionalDomainRequest, DeleteProfessionalDomainResponse>
  {
    public static Result<DeleteProfessionalDomainResponse> Execute(
      DeleteProfessionalDomainRequest request
    )
    {
      var record = GetProfessionalRecord(request);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<DeleteProfessionalDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteProfessionalDomainResponse>.Success(
        new DeleteProfessionalDomainResponse { ProfessionalId = record.ProfessionalId.Value }
      );
    }

    private static ProfessionalRecord GetProfessionalRecord(DeleteProfessionalDomainRequest request)
    {
      var id = new ProfessionalIdValueObject(request.ProfessionalId);
      return new ProfessionalRecord { ProfessionalId = id };
    }
  }
}
