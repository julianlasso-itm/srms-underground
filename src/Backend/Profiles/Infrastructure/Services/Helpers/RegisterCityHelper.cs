using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterCityHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<RegisterCityProfilesResponse> RegisterCityAsync(
      RegisterCityProfilesRequest request
    )
    {
      var cityCommand = MapToRegisterCityCommand(request);
      var data = await Application.RegisterCity(cityCommand);
      return MapToRegisterCityResponse(data);
    }

    private static RegisterCityCommand MapToRegisterCityCommand(RegisterCityProfilesRequest request)
    {
      return new RegisterCityCommand { Name = request.Name, ProvinceId = request.ProvinceId };
    }

    private static RegisterCityProfilesResponse MapToRegisterCityResponse(
      RegisterCityApplicationResponse data
    )
    {
      return new RegisterCityProfilesResponse
      {
        CityId = data.CityId,
        ProvinceId = data.ProvinceId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
