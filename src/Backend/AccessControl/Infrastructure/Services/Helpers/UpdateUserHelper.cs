using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class UpdateUserHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateUserAccessControlResponse> UpdateUserAsync(
      UpdateUserAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToUpdateUserCommand(request);
      var data = await Application.UpdateUser(command);
      return AclOutputMapper.ToUpdateUserResponse(data);
    }
  }
}
