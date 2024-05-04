using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class UpdateRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateRoleAccessControlResponse> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToUpdateRoleCommand(request);
      var data = await Application.UpdateRole(command);
      return AclOutputMapper.ToUpdateRoleResponse(data);
    }
  }
}
