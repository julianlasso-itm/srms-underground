using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class RegisterProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<
      Result<RegisterProfessionalProfilesResponse>
    > RegisterProfessionalAsync(RegisterProfessionalProfilesRequest request)
    {
      var newUserCommand = MapToNewUserCommand(request);
      var response = await Application.RegisterProfessional(newUserCommand);

      if (response.IsFailure)
      {
        return Response<RegisterProfessionalProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterProfessionalProfilesResponse>.Success(
        MapToRegisterProfessionalResponse(response.Data)
      );
    }

    private static RegisterProfessionalCommand MapToNewUserCommand(
      RegisterProfessionalProfilesRequest request
    )
    {
      return new RegisterProfessionalCommand
      {
        Name = request.Name,
        Email = request.Email,
        Disabled = request.Disabled
      };
    }

    private static RegisterProfessionalProfilesResponse MapToRegisterProfessionalResponse(
      RegisterProfessionalApplicationResponse data
    )
    {
      return new RegisterProfessionalProfilesResponse
      {
        Name = data.Name,
        Email = data.Email,
        Disabled = data.Disabled
      };
    }
  }
}
