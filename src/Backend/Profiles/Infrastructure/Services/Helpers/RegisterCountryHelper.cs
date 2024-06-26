using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class RegisterCountryHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<RegisterCountryProfilesResponse>> RegisterCountryAsync(
      RegisterCountryProfilesRequest request
    )
    {
      var countryCommand = MapToRegisterCountryCommand(request);
      var response = await Application.RegisterCountry(countryCommand);

      if (response.IsFailure)
      {
        return Response<RegisterCountryProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<RegisterCountryProfilesResponse>.Success(
        MapToRegisterCountryResponse(response.Data)
      );
    }

    private static RegisterCountryCommand MapToRegisterCountryCommand(
      RegisterCountryProfilesRequest request
    )
    {
      return new RegisterCountryCommand { Name = request.Name };
    }

    private static RegisterCountryProfilesResponse MapToRegisterCountryResponse(
      RegisterCountryApplicationResponse data
    )
    {
      return new RegisterCountryProfilesResponse
      {
        CountryId = data.CountryId,
        Name = data.Name,
        Disabled = data.Disabled,
      };
    }
  }
}
