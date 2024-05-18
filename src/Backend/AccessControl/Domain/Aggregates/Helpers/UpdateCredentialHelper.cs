using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class UpdateCredentialHelper
    : BaseHelper,
      IHelper<UpdateCredentialDomainRequest, UpdateCredentialDomainResponse>
  {
    public static UpdateCredentialDomainResponse Execute(UpdateCredentialDomainRequest data)
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

      ValidateRecordFields(credential);
      ValidateAmountDataToBeUpdated(response);

      return response;
    }

    private static CredentialRecord GetCredentialRecord(UpdateCredentialDomainRequest data)
    {
      var id = new CredentialIdValueObject(data.CredentialId);
      return new CredentialRecord { CredentialId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateCredentialDomainResponse response)
    {
      var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
      if (count == 1)
      {
        throw new DomainException(
          "No data to update",
          [new ErrorValueObject("No fields to update", "No fields to update")]
        );
      }
    }
  }
}
