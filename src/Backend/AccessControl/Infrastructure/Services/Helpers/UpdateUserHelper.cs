using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  public class UpdateUserHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateUserAccessControlResponse>> UpdateUserAsync(
      UpdateUserAccessControlRequest request
    )
    {
      var command = AclInputMapper.ToUpdateUserCommand(request);
      var data = await Application.UpdateUser(command);

      if (data.IsFailure)
      {
        return Response<UpdateUserAccessControlResponse>.Failure(
          data.Message,
          data.Code,
          data.Details
        );
      }

      return Response<UpdateUserAccessControlResponse>.Success(
        AclOutputMapper.ToUpdateUserResponse(data.Data)
      );
    }
  }
}
