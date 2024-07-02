using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterRoleHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterRoleProfilesResponse>> RegisterRoleAsync(
      RegisterRoleProfilesRequest request
    )
    {
      var newRoleCommand = MapToRegisterRoleCommand(request);
      var response = await Application.RegisterRole(newRoleCommand);

      if (response.IsFailure)
      {
        return Response<RegisterRoleProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterRoleProfilesResponse>.Success(
        MapToRegisterRoleResponse(response.Data)
      );
    }

    private static RegisterRoleCommand MapToRegisterRoleCommand(RegisterRoleProfilesRequest request)
    {
      return new RegisterRoleCommand
      {
        Name = request.Name,
        Description = request.Description,
        Skills = request.Skills
      };
    }

    private static RegisterRoleProfilesResponse MapToRegisterRoleResponse(
      RegisterRoleApplicationResponse data
    )
    {
      return new RegisterRoleProfilesResponse
      {
        RoleId = data.RoleId,
        Name = data.Name,
        Description = data.Description,
        Disabled = data.Disabled,
        Skills = data.Skills,
      };
    }
  }
}
