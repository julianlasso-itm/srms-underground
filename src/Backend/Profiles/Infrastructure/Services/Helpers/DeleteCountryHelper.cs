using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<DeleteCountryProfilesResponse>> DeleteCountryAsync(
      DeleteCountryProfilesRequest request
    )
    {
      var deleteCountryCommand = MapToDeleteCountryCommand(request);
      var response = await Application.DeleteCountry(deleteCountryCommand);

      if (response.IsFailure)
      {
        return Response<DeleteCountryProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<DeleteCountryProfilesResponse>.Success(
        MapToDeleteCountryResponse(response.Data)
      );
    }

    private static DeleteCountryCommand MapToDeleteCountryCommand(
      DeleteCountryProfilesRequest request
    )
    {
      return new DeleteCountryCommand { CountryId = request.CountryId };
    }

    private static DeleteCountryProfilesResponse MapToDeleteCountryResponse(
      DeleteCountryApplicationResponse data
    )
    {
      return new DeleteCountryProfilesResponse { CountryId = data.CountryId };
    }
  }
}
