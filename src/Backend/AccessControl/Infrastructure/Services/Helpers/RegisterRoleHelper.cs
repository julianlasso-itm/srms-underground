using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterRoleAccessControlResponse>> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToRegisterRoleCommand(request);
      var data = await Application.RegisterRole(command);

      if (data.IsFailure)
      {
        return Response<RegisterRoleAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<RegisterRoleAccessControlResponse>.Success(
        AclOutputMapper.ToRegisterRoleResponse(data.Data)
      );
    }
  }
}
