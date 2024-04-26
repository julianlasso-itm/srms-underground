using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class GetCitiesHelper : BaseHelperServiceInfrastructure
{
    public static async Task<GetCitiesResponse> GetCitiesAsync(GetCitiesRequest request)
    {
        var getCitiesCommand = MapToGetCitiesCommand(request);
        var data = await Application.GetCities(getCitiesCommand);
        return MapToGetCitiesResponse(data);
    }

    private static GetCitiesCommand MapToGetCitiesCommand(GetCitiesRequest request)
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

    private static GetCitiesResponse MapToGetCitiesResponse(
        GetCitiesApplicationResponse<CityModel> data
    )
    {
        return new GetCitiesResponse
        {
            Cities = data
                .Cities.Select(city => new City
                {
                    CityId = city.CityId.ToString(),
                    ProvinceId = city.ProvinceId.ToString(),
                    Name = city.Name,
                    Disabled = city.Disabled
                })
                .ToList(),
            Total = data.Total
        };
    }
}
