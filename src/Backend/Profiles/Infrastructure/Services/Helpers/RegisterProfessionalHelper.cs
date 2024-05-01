using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class RegisterProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterProfessionalProfilesResponse> RegisterProfessionalAsync(
      RegisterProfessionalProfilesRequest request
    )
    {
      var newUserCommand = MapToNewUserCommand(request);
      var data = await Application.RegisterProfessional(newUserCommand);
      return MapToRegisterProfessionalResponse(data);
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
