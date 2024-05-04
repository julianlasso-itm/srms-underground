using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class DeleteRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteRoleAccessControlResponse> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToDeleteRoleCommand(request);
      var data = await Application.DeleteRole(command);
      return AclOutputMapper.ToDeleteRoleResponse(data);
    }
  }
}
