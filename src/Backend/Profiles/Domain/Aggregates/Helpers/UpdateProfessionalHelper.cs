using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Enums;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class UpdateProfessionalHelper
    : BaseHelper,
      IHelper<UpdateProfessionalDomainRequest, UpdateProfessionalDomainResponse>
  {
    public static Result<UpdateProfessionalDomainResponse> Execute(
      UpdateProfessionalDomainRequest data
    )
    {
      var record = GetProfessionalRecord(data);
      var professional = new ProfessionalEntity(record);
      var response = new UpdateProfessionalDomainResponse
      {
        ProfessionalId = professional.ProfessionalId.Value
      };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        professional.UpdateName(name);
        response.Name = professional.Name.Value;
      }

      if (data.Email != null)
      {
        professional.UpdateEmail(new EmailValueObject(data.Email));
        response.Email = professional.Email.Value;
      }

      if (data.Disable != null)
      {
        if (data.Disable == true)
        {
          professional.Disable();
        }
        else
        {
          professional.Enable();
        }
        response.Disabled = professional.Disabled.Value;
      }

      var validateRecordFields = ValidateRecordFields(professional);

      if (validateRecordFields.IsFailure)
      {
        return Response<UpdateProfessionalDomainResponse>.Failure(
          validateRecordFields.Message,
          validateRecordFields.Code,
          validateRecordFields.Details
        );
      }

      var validateAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);

      if (validateAmountDataToBeUpdated.IsFailure)
      {
        return Response<UpdateProfessionalDomainResponse>.Failure(
          validateAmountDataToBeUpdated.Message,
          validateAmountDataToBeUpdated.Code,
          validateAmountDataToBeUpdated.Details
        );
      }

      return Response<UpdateProfessionalDomainResponse>.Success(response);
    }

    private static Result<bool> ValidateAmountDataToBeUpdated(
      UpdateProfessionalDomainResponse response
    )
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        return Response<bool>.Failure(
          "No data to update",
          ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("Fields", "No fields to update")
        );
      }

      return Response<bool>.Success();
    }

    private static ProfessionalRecord GetProfessionalRecord(UpdateProfessionalDomainRequest data)
    {
      var id = new ProfessionalIdValueObject(data.ProfessionalId);
      return new ProfessionalRecord { ProfessionalId = id };
    }
  }
}
