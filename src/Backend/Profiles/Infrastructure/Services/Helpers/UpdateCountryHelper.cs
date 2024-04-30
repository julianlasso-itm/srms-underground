using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateCountryResponse> UpdateCountryAsync(UpdateCountryRequest request)
    {
      var updateCountryCommand = MapToUpdateCountryCommand(request);
      var data = await Application.UpdateCountry(updateCountryCommand);
      return MapToUpdateCountryResponse(data);
    }

    private static UpdateCountryCommand MapToUpdateCountryCommand(UpdateCountryRequest request)
    {
      return new UpdateCountryCommand
      {
        CountryId = request.CountryId!,
        Name = request.Name,
        Disable = request.Disable
      };
    }

    private static UpdateCountryResponse MapToUpdateCountryResponse(
      UpdateCountryApplicationResponse data
    )
    {
      return new UpdateCountryResponse
      {
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
