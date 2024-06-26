using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class UpdateProvinceHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<UpdateProvinceProfilesResponse>> UpdateProvinceAsync(
      UpdateProvinceProfilesRequest request
    )
    {
      var updateProvinceCommand = MapToUpdateProvinceCommand(request);
      var response = await Application.UpdateProvince(updateProvinceCommand);

      if (response.IsFailure)
      {
        return Response<UpdateProvinceProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<UpdateProvinceProfilesResponse>.Success(
        MapToUpdateProvinceResponse(response.Data)
      );
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
