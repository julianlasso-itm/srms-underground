using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class GetProvincesHelper : BaseHelperServiceInfrastructure
{
    public static async Task<GetProvincesResponse> GetProvincesAsync(GetProvincesRequest request)
    {
        var getProvincesCommand = MapToGetProvincesCommand(request);
        var data = await Application.GetProvinces(getProvincesCommand);
        return MapToGetProvincesResponse(data);
    }

    private static GetProvincesCommand MapToGetProvincesCommand(GetProvincesRequest request)
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

    private static GetProvincesResponse MapToGetProvincesResponse(
        GetProvincesApplicationResponse<ProvinceModel> data
    )
    {
        return new GetProvincesResponse
        {
            Provinces = data
                .Provinces.Select(province => new Province
                {
                    ProvinceId = province.ProvinceId.ToString(),
                    CountryId = province.CountryId.ToString(),
                    Name = province.Name,
                    Disabled = province.Disabled,
                    Country = new Country
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
