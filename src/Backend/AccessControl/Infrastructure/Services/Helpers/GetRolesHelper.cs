using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class GetRolesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<GetRolesAccessControlResponse> GetRolesAsync(
      GetRolesAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToGetRolesCommand(request);
      var data = await Application.GetRoles(command);
      return AclOutputMapper.ToGetRolesResponse(data);
    }
  }
}
