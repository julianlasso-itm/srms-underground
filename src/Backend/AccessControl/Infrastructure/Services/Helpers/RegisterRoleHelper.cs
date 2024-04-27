using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class RegisterRoleHelper : BaseHelperServiceInfrastructure
{
    public static async Task<RegisterRoleSecurityResponse> RegisterRoleAsync(
        RegisterRoleSecurityRequest request
    )
    {
        var newRoleCommand = MapToRegisterRoleCommand(request);
        var data = await Application.RegisterRole(newRoleCommand);
        return MapToRegisterRoleResponse(data);
    }

    private static RegisterRoleCommand MapToRegisterRoleCommand(RegisterRoleSecurityRequest request)
    {
        return new RegisterRoleCommand { Name = request.Name, Description = request.Description, };
    }

    private static RegisterRoleSecurityResponse MapToRegisterRoleResponse(
        RegisterRoleApplicationResponse data
    )
    {
        return new RegisterRoleSecurityResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
    }
}
