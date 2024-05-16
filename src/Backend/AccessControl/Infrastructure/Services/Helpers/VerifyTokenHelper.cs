using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class VerifyTokenHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<VerifyTokenAccessControlResponse> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request
    )
    {
      request.PublicKeyPath = Configuration.GetVariable("PUBLIC_KEY_PATH");
      request.PrivateKeyPath = Configuration.GetVariable("PRIVATE_KEY_PATH");
      var command = AclInputMapper.ToVerifyTokenCommand(request);
      var data = await Application.VerifyToken(command);
      return AclOutputMapper.ToVerifyTokenResponse(data);
    }
  }
}
