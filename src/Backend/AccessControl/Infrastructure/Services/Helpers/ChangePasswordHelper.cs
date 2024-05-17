using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class ChangePasswordHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<ChangePasswordAccessControlResponse> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToChangePasswordCommand(request);
      var data = await Application.ChangePassword(command);
      return AclOutputMapper.ToChangePasswordResponse(data);
    }
  }
}
