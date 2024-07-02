using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterProvinceHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterProvinceProfilesResponse>> RegisterProvinceAsync(
      RegisterProvinceProfilesRequest request
    )
    {
      var provinceCommand = MapToRegisterProvinceCommand(request);
      var response = await Application.RegisterProvince(provinceCommand);

      if (response.IsFailure)
      {
        return Response<RegisterProvinceProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterProvinceProfilesResponse>.Success(
        MapToRegisterProvinceResponse(response.Data)
      );
    }

    private static RegisterProvinceCommand MapToRegisterProvinceCommand(
      RegisterProvinceProfilesRequest request
    )
    {
      return new RegisterProvinceCommand { Name = request.Name, CountryId = request.CountryId };
    }

    private static RegisterProvinceProfilesResponse MapToRegisterProvinceResponse(
      RegisterProvinceApplicationResponse data
    )
    {
      return new RegisterProvinceProfilesResponse
      {
        ProvinceId = data.ProvinceId,
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
