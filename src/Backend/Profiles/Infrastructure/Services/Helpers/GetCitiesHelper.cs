using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class GetCitiesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetCitiesProfilesResponse>> GetCitiesAsync(
      GetCitiesProfilesRequest request
    )
    {
      var getCitiesCommand = MapToGetCitiesCommand(request);
      var response = await Application.GetCities(getCitiesCommand);

      if (response.IsFailure)
      {
        return Response<GetCitiesProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<GetCitiesProfilesResponse>.Success(MapToGetCitiesResponse(response.Data));
    }

    private static GetCitiesCommand MapToGetCitiesCommand(GetCitiesProfilesRequest request)
    {
      return new GetCitiesCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetCitiesProfilesResponse MapToGetCitiesResponse(
      GetCitiesApplicationResponse<CityModel> data
    )
    {
      return new GetCitiesProfilesResponse
      {
        Cities = data
          .Cities.Select(city => new CityProfiles
          {
            CityId = city.CityId.ToString(),
            ProvinceId = city.ProvinceId.ToString(),
            Name = city.Name,
            Disabled = city.Disabled,
            Province = new ProvinceProfiles
            {
              ProvinceId = city.Province.ProvinceId.ToString(),
              CountryId = city.Province.CountryId.ToString(),
              Name = city.Province.Name,
              Disabled = city.Province.Disabled,
              Country = new CountryProfiles
              {
                CountryId = city.Province.Country.CountryId.ToString(),
                Name = city.Province.Country.Name,
                Disabled = city.Province.Country.Disabled
              }
            }
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
