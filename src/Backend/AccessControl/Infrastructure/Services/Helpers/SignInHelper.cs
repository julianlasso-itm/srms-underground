using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class SignInHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<SignInAccessControlResponse> SignInAsync(
      SignInAccessControlRequest request
    )
    {
      request.PublicKeyPath = Configuration.GetVariable("PUBLIC_KEY_PATH");
      request.PrivateKeyPath = Configuration.GetVariable("PRIVATE_KEY_PATH");
      var command = AclInputMapper.ToSignInCommand(request);
      var data = await Application.SignIn(command);
      return AclOutputMapper.ToSignInResponse(data);
    }
  }
}
