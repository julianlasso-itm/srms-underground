using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class RegisterCityHelper : BaseHelperServiceInfrastructure
{
    public static async Task<RegisterCityResponse> RegisterCityAsync(RegisterCityRequest request)
    {
        var cityCommand = MapToRegisterCityCommand(request);
        var data = await Application.RegisterCity(cityCommand);
        return MapToRegisterCityResponse(data);
    }

    private static RegisterCityCommand MapToRegisterCityCommand(RegisterCityRequest request)
    {
        return new RegisterCityCommand { Name = request.Name, ProvinceId = request.ProvinceId };
    }

    private static RegisterCityResponse MapToRegisterCityResponse(
        RegisterCityApplicationResponse data
    )
    {
        return new RegisterCityResponse
        {
            CityId = data.CityId,
            ProvinceId = data.ProvinceId,
            Name = data.Name,
            Disabled = data.Disabled,
        };
    }
}
