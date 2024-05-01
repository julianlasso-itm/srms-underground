using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class DeleteCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<DeleteCountryProfilesResponse> DeleteCountryAsync(
      DeleteCountryProfilesRequest request
    )
    {
      var deleteCountryCommand = MapToDeleteCountryCommand(request);
      var data = await Application.DeleteCountry(deleteCountryCommand);
      return MapToDeleteCountryResponse(data);
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
