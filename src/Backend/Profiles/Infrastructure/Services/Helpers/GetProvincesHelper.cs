using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class GetProvincesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetProvincesProfilesResponse>> GetProvincesAsync(
      GetProvincesProfilesRequest request
    )
    {
      var getProvincesCommand = MapToGetProvincesCommand(request);
      var response = await Application.GetProvinces(getProvincesCommand);

      if (response.IsFailure)
      {
        return Response<GetProvincesProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<GetProvincesProfilesResponse>.Success(
        MapToGetProvincesResponse(response.Data)
      );
    }

    private static GetProvincesCommand MapToGetProvincesCommand(GetProvincesProfilesRequest request)
    {
      return new GetProvincesCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetProvincesProfilesResponse MapToGetProvincesResponse(
      GetProvincesApplicationResponse<ProvinceModel> data
    )
    {
      return new GetProvincesProfilesResponse
      {
        Provinces = data
          .Provinces.Select(province => new ProvinceProfiles
          {
            ProvinceId = province.ProvinceId.ToString(),
            CountryId = province.CountryId.ToString(),
            Name = province.Name,
            Disabled = province.Disabled,
            Country = new CountryProfiles
            {
              CountryId = province.Country.CountryId.ToString(),
              Name = province.Country.Name,
              Disabled = province.Country.Disabled
            }
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
