using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteCityHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteCityProfilesResponse> DeleteCityAsync(
      DeleteCityProfilesRequest request
    )
    {
      var deleteCityCommand = MapToDeleteCityCommand(request);
      var data = await Application.DeleteCity(deleteCityCommand);
      return MapToDeleteCityResponse(data);
    }

    private static DeleteCityCommand MapToDeleteCityCommand(DeleteCityProfilesRequest request)
    {
      return new DeleteCityCommand { CityId = request.CityId };
    }

    private static DeleteCityProfilesResponse MapToDeleteCityResponse(
      DeleteCityApplicationResponse data
    )
    {
      return new DeleteCityProfilesResponse { CityId = data.CityId };
    }
  }
}
