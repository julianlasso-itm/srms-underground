using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers
{
  internal class RegisterUserHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterUserResponse>> RegisterUserAsync(
      RegisterUserRequest request
    )
    {
      var command = AclInputMapper.ToRegisterUserCommand(request);
      var data = await Application.RegisterUser(command);

      if (data.IsFailure)
      {
        return Response<RegisterUserResponse>.Failure(data.Message, data.Code, data.Details);
      }

      return Response<RegisterUserResponse>.Success(
        AclOutputMapper.ToRegisterUserResponse(data.Data)
      );
    }
  }
}
