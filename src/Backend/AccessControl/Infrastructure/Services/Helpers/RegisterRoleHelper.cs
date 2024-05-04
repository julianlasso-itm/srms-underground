using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterRoleAccessControlResponse> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToRegisterRoleCommand(request);
      var data = await Application.RegisterRole(command);
      return AclOutputMapper.ToRegisterRoleResponse(data);
    }
  }
}
