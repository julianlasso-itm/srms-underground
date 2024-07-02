using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class UpdateCityHelper : BaseHelperServiceInfrastructure
{
  public static async Task<Result<UpdateCityProfilesResponse>> UpdateCityAsync(
    UpdateCityProfilesRequest request
  )
  {
    var updateCityCommand = MapToUpdateCityCommand(request);
    var response = await Application.UpdateCity(updateCityCommand);

    if (response.IsFailure)
    {
      return Response<UpdateCityProfilesResponse>.Failure(
        response.Message,
        response.Code,
        response.Details
      );
    }

    return Response<UpdateCityProfilesResponse>.Success(MapToUpdateCityResponse(response.Data));
  }

  private static UpdateCityCommand MapToUpdateCityCommand(UpdateCityProfilesRequest request)
  {
    return new UpdateCityCommand
    {
      CityId = request.CityId!,
      ProvinceId = request.ProvinceId,
      Name = request.Name,
      Disable = request.Disable
    };
  }

  private static UpdateCityProfilesResponse MapToUpdateCityResponse(
    UpdateCityApplicationResponse data
  )
  {
    return new UpdateCityProfilesResponse
    {
      CityId = data.CityId,
      ProvinceId = data.ProvinceId,
      Name = data.Name,
      Disabled = data.Disabled,
    };
  }
}
