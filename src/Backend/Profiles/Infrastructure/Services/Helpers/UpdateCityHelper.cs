using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class UpdateCityHelper : BaseHelperServiceInfrastructure
{
    public static async Task<UpdateCityResponse> UpdateCityAsync(UpdateCityRequest request)
    {
        var updateCityCommand = MapToUpdateCityCommand(request);
        var data = await Application.UpdateCity(updateCityCommand);
        return MapToUpdateCityResponse(data);
    }

    private static UpdateCityCommand MapToUpdateCityCommand(UpdateCityRequest request)
    {
        return new UpdateCityCommand
        {
            CityId = request.CityId!,
            ProvinceId = request.ProvinceId,
            Name = request.Name,
            Disable = request.Disable
        };
    }

    private static UpdateCityResponse MapToUpdateCityResponse(UpdateCityApplicationResponse data)
    {
        return new UpdateCityResponse
        {
            CityId = data.CityId,
            ProvinceId = data.ProvinceId,
            Name = data.Name,
            Disabled = data.Disabled,
        };
    }
}
