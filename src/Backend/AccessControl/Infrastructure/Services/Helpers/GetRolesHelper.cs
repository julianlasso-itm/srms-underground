using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Infrastructure.Persistence.Models;
using AccessControl.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services.Helpers;

internal class GetRolesHelper : BaseHelperServiceInfrastructure
{
    public static async Task<GetRolesSecurityResponse> GetRolesAsync(
        GetRolesSecurityRequest request
    )
    {
        var getRolesCommand = MapToGetRolesCommand(request);
        var data = await Application.GetRoles(getRolesCommand);
        return MapToGetRolesResponse(data);
    }

    private static GetRolesCommand MapToGetRolesCommand(GetRolesSecurityRequest request)
    {
        return new GetRolesCommand
        {
            Page = request.Page,
            Limit = request.Limit,
            Filter = request.Filter,
            FilterBy = request.FilterBy,
            Sort = request.Sort,
            Order = request.Order
        };
    }

    private static GetRolesSecurityResponse MapToGetRolesResponse(
        GetRolesApplicationResponse<RoleModel> data
    )
    {
        return new GetRolesSecurityResponse
        {
            Roles = data
                .Roles.Select(role => new RoleSecurity
                {
                    RoleId = role.RoleId.ToString(),
                    Name = role.Name,
                    Description = role.Description,
                    Disabled = role.Disabled
                })
                .ToList(),
            Total = data.Total
        };
    }
}
