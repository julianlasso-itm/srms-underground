using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities;
using AccessControl.Domain.Entities.Structs;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal abstract class RegisterRoleHelper
    : BaseHelper,
      IHelper<RegisterRoleDomainRequest, RegisterRoleDomainResponse>
  {
    public static RegisterRoleDomainResponse Execute(RegisterRoleDomainRequest request)
    {
      var @struct = GetRoleStruct(request);
      ValidateStructureFields(@struct);

      var role = new RoleEntity();
      role.Register(@struct.Name, @struct.Description);

      return MapToResponse(role);
    }

    private static RoleStruct GetRoleStruct(RegisterRoleDomainRequest request)
    {
      var name = new NameValueObject(request.Name);
      var description =
        request.Description != null ? new DescriptionValueObject(request.Description) : null;

      return new RoleStruct { Name = name, Description = description };
    }

    private static RegisterRoleDomainResponse MapToResponse(RoleEntity role)
    {
      return new RegisterRoleDomainResponse
      {
        RoleId = role.RoleId.Value,
        Name = role.Name.Value,
        Description = role.Description?.Value,
        Disabled = role.Disabled.Value,
      };
    }
  }
}
