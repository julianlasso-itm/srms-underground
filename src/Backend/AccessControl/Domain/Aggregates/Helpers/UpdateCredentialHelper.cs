using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class UpdateCredentialHelper : BaseHelper, IHelper<UpdateCredentialDomainRequest>
  {
    public static Result Execute(UpdateCredentialDomainRequest data)
    {
      var record = GetCredentialRecord(data);
      var credential = new CredentialEntity(record);
      var response = new UpdateCredentialDomainResponse
      {
        CredentialId = credential.CredentialId.Value
      };

      if (data.Name != null)
      {
        var name = new FullNameValueObject(data.Name);
        credential.UpdateName(name);
        response.Name = credential.Name.Value;
      }

      if (data.Avatar != null)
      {
        var avatar = new AvatarValueObject(data.Avatar);
        credential.UpdateAvatar(avatar);
        response.Avatar = credential.Avatar.Value;
        response.AvatarExtension = data.AvatarExtension;
      }

      if (data.Disabled != null)
      {
        if (data.Disabled == true)
        {
          credential.Disable();
        }
        else
        {
          credential.Enable();
        }
        response.Disabled = credential.Disabled.Value;
      }

      if (data.CityId != null)
      {
        response.CityId = data.CityId;
      }

      var resultValidationFields = ValidateRecordFields(credential);
      if (resultValidationFields.IsFailure)
      {
        return resultValidationFields;
      }

      var resultValidationAmountDataToBeUpdated = ValidateAmountDataToBeUpdated(response);
      if (resultValidationAmountDataToBeUpdated.IsFailure)
      {
        return resultValidationAmountDataToBeUpdated;
      }

      return new SuccessResult<UpdateCredentialDomainResponse>(response);
    }

    private static CredentialRecord GetCredentialRecord(UpdateCredentialDomainRequest data)
    {
      var id = new CredentialIdValueObject(data.CredentialId);
      return new CredentialRecord { CredentialId = id };
    }

    private static Result ValidateAmountDataToBeUpdated(UpdateCredentialDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        return new ErrorResult(
          "No data to update",
          Shared.Common.Enums.ErrorEnum.BAD_REQUEST,
          new ErrorValueObject("fields", "No fields to update")
        );
      }

      return new SuccessResult<bool>();
    }
  }
}
