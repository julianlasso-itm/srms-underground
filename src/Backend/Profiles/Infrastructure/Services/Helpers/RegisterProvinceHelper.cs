using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers;

internal class RegisterProvinceHelper : BaseHelperServiceInfrastructure
{
    public static async Task<RegisterProvinceResponse> RegisterProvinceAsync(
        RegisterProvinceRequest request
    )
    {
        var provinceCommand = MapToRegisterProvinceCommand(request);
        var data = await Application.RegisterProvince(provinceCommand);
        return MapToRegisterProvinceResponse(data);
    }

    private static RegisterProvinceCommand MapToRegisterProvinceCommand(
        RegisterProvinceRequest request
    )
    {
        return new RegisterProvinceCommand { Name = request.Name };
    }

    private static RegisterProvinceResponse MapToRegisterProvinceResponse(
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
