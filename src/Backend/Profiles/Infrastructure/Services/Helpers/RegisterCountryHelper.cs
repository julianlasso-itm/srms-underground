using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterCountryProfilesResponse> RegisterCountryAsync(
      RegisterCountryProfilesRequest request
    )
    {
      var countryCommand = MapToRegisterCountryCommand(request);
      var data = await Application.RegisterCountry(countryCommand);
      return MapToRegisterCountryResponse(data);
    }

    private static RegisterCountryCommand MapToRegisterCountryCommand(
      RegisterCountryProfilesRequest request
    )
    {
      return new RegisterCountryCommand { Name = request.Name };
    }

    private static RegisterCountryProfilesResponse MapToRegisterCountryResponse(
      RegisterCountryApplicationResponse data
    )
    {
      return new RegisterCountryProfilesResponse
      {
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
