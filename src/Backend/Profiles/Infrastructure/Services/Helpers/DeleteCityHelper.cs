using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteCityHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteCityProfilesResponse>> DeleteCityAsync(
      DeleteCityProfilesRequest request
    )
    {
      var deleteCityCommand = MapToDeleteCityCommand(request);
      var response = await Application.DeleteCity(deleteCityCommand);

      if (response.IsFailure)
      {
        return Response<DeleteCityProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteCityProfilesResponse>.Success(MapToDeleteCityResponse(response.Data));
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
