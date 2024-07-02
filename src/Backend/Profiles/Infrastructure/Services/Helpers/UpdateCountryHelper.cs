using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateCountryProfilesResponse>> UpdateCountryAsync(
      UpdateCountryProfilesRequest request
    )
    {
      var updateCountryCommand = MapToUpdateCountryCommand(request);
      var response = await Application.UpdateCountry(updateCountryCommand);

      if (response.IsFailure)
      {
        return Response<UpdateCountryProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<UpdateCountryProfilesResponse>.Success(
        MapToUpdateCountryResponse(response.Data)
      );
    }

    private static UpdateCountryCommand MapToUpdateCountryCommand(
      UpdateCountryProfilesRequest request
    )
    {
      return new UpdateCountryCommand
      {
        CountryId = request.CountryId!,
        Name = request.Name,
        Disable = request.Disable
      };
    }

    private static UpdateCountryProfilesResponse MapToUpdateCountryResponse(
      UpdateCountryApplicationResponse data
    )
    {
      return new UpdateCountryProfilesResponse
      {
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
