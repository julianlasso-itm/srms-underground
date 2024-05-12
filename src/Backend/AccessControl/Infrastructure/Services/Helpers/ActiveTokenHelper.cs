using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class ActiveTokenHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<ActivationTokenAccessControlResponse> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToActivateTokenCommand(request);
      var data = await Application.ActivateToken(command);
      return AclOutputMapper.ToActivateTokenResponse(data);
    }
  }
}
