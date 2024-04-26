using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class RegisterCityHelper : BaseHelperServiceInfrastructure
{
    public static async Task<RegisterCityResponse> RegisterRoleAsync(RegisterCityRequest request)
    {
        var cityCommand = MapToRegisterRoleCommand(request);
        var data = await Application.RegisterCity(cityCommand);
        return MapToRegisterRoleResponse(data);
    }

    private static RegisterCityCommand MapToRegisterRoleCommand(RegisterCityRequest request)
    {
        return new RegisterCityCommand { Name = request.Name };
    }

    private static RegisterCityResponse MapToRegisterRoleResponse(
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
