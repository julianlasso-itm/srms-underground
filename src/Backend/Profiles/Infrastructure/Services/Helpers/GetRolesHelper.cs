using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  internal class GetRolesHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<GetRolesProfilesResponse> GetRolesAsync(
      GetRolesProfilesRequest request
    )
    {
      var getRolesCommand = MapToGetRolesCommand(request);
      var data = await Application.GetRoles(getRolesCommand);
      return MapToGetRolesResponse(data);
    }

    private static GetRolesCommand MapToGetRolesCommand(GetRolesProfilesRequest request)
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

    private static GetRolesProfilesResponse MapToGetRolesResponse(
      GetRolesApplicationResponse<RoleModel> data
    )
    {
      return new GetRolesProfilesResponse
      {
        Roles = data
          .Roles.Select(role => new RoleProfiles
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
}
