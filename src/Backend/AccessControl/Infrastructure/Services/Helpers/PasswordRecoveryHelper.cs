using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class PasswordRecoveryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<PasswordRecoveryAccessControlResponse> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToPasswordRecoveryCommand(request);
      var data = await Application.PasswordRecovery(command);
      return AclOutputMapper.ToPasswordRecoveryResponse(data);
    }
  }
}
