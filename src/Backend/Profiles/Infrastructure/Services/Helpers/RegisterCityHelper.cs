using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterCityHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterCityProfilesResponse>> RegisterCityAsync(
      RegisterCityProfilesRequest request
    )
    {
      var cityCommand = MapToRegisterCityCommand(request);
      var response = await Application.RegisterCity(cityCommand);

      if (response.IsFailure)
      {
        return Response<RegisterCityProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterCityProfilesResponse>.Success(
        MapToRegisterCityResponse(response.Data)
      );
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
