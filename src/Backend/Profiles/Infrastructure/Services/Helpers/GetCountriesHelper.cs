using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class GetCountriesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<GetCountriesProfilesResponse> GetCountriesAsync(
      GetCountriesProfilesRequest request
    )
    {
      var getCountriesCommand = MapToGetCountriesCommand(request);
      var data = await Application.GetCountries(getCountriesCommand);
      return MapToGetCountriesResponse(data);
    }

    private static GetCountriesCommand MapToGetCountriesCommand(GetCountriesProfilesRequest request)
    {
      return new GetCountriesCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetCountriesProfilesResponse MapToGetCountriesResponse(
      GetCountriesApplicationResponse<CountryModel> data
    )
    {
      return new GetCountriesProfilesResponse
      {
        Countries = data
          .Countries.Select(country => new CountryProfiles
          {
            CountryId = country.CountryId.ToString(),
            Name = country.Name,
            Disabled = country.Disabled
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
