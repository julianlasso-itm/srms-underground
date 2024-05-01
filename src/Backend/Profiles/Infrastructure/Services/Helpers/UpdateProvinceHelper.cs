using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateProvinceHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<UpdateProvinceProfilesResponse> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request
    )
    {
      var updateProvinceCommand = MapToUpdateProvinceCommand(request);
      var data = await Application.UpdateProvince(updateProvinceCommand);
      return MapToUpdateProvinceResponse(data);
    }

    private static UpdateProvinceCommand MapToUpdateProvinceCommand(
      UpdateProvinceProfilesRequest request
    )
    {
      return new UpdateProvinceCommand
      {
        ProvinceId = request.ProvinceId!,
        CountryId = request.CountryId,
        Name = request.Name,
        Disable = request.Disable
      };
    }

    private static UpdateProvinceProfilesResponse MapToUpdateProvinceResponse(
      UpdateProvinceApplicationResponse data
    )
    {
      return new UpdateProvinceProfilesResponse
      {
        ProvinceId = data.ProvinceId,
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
