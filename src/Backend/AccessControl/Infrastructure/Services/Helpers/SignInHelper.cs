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
      var command = AclInputMapper.ToSignInCommand(request);
      var data = await Application.SignIn(command);
      return AclOutputMapper.ToSignInResponse(data);
    }
  }
}
