using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class RegisterProvinceHelper : BaseHelperServiceInfrastructure
{
    public static async Task<RegisterProvinceResponse> RegisterRoleAsync(
        RegisterProvinceRequest request
    )
    {
        var provinceCommand = MapToRegisterRoleCommand(request);
        var data = await Application.RegisterProvince(provinceCommand);
        return MapToRegisterRoleResponse(data);
    }

    private static RegisterProvinceCommand MapToRegisterRoleCommand(RegisterProvinceRequest request)
    {
        return new RegisterProvinceCommand { Name = request.Name };
    }

    private static RegisterProvinceResponse MapToRegisterRoleResponse(
        RegisterProvinceApplicationResponse data
    )
    {
        return new RegisterProvinceResponse
        {
            ProvinceId = data.ProvinceId,
            CountryId = data.CountryId,
            Name = data.Name,
            Disabled = data.Disabled,
        };
    }
}
