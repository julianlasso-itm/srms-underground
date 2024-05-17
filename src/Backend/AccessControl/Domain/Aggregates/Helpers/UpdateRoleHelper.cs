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
  internal class UpdateRoleHelper
    : BaseHelper,
      IHelper<UpdateRoleDomainRequest, UpdateRoleDomainResponse>
  {
    public static UpdateRoleDomainResponse Execute(UpdateRoleDomainRequest data)
    {
      var record = GetRoleRecord(data);
      var role = new RoleEntity(record);
      var response = new UpdateRoleDomainResponse { RoleId = role.RoleId.Value };

      if (data.Name != null)
      {
        var name = new NameValueObject(data.Name);
        role.UpdateName(name);
        response.Name = role.Name.Value;
      }

      if (data.Description != null)
      {
        var description = new DescriptionValueObject(data.Description);
        role.UpdateDescription(description);
        response.Description = role.Description?.Value;
      }

      if (data.Disable != null)
      {
        if (data.Disable == true)
        {
          role.Disable();
        }
        else
        {
          role.Enable();
        }
        response.Disabled = role.Disabled.Value;
      }

      ValidateRecordFields(role);
      ValidateAmountDataToBeUpdated(response);

      return response;
    }

    private static RoleRecord GetRoleRecord(UpdateRoleDomainRequest data)
    {
      var id = new RoleIdValueObject(data.RoleId);
      return new RoleRecord { RoleId = id };
    }

    private static void ValidateAmountDataToBeUpdated(UpdateRoleDomainResponse response)
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
