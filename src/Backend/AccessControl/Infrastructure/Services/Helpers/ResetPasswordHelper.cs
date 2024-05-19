using AccessControl.Infrastructure.Services.Helpers.Base;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class ResetPasswordHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<ResetPasswordAccessControlResponse> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToResetPasswordCommand(request);
      var data = await Application.ResetPassword(command);
      return AclOutputMapper.ToResetPasswordResponse(data);
    }
  }
}
