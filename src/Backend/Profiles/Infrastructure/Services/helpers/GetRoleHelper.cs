// Licensed to the .NET Foundation under one or more agreements.

using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class GetRolesHelper
    {
        private static Application<Country, State, City, Skill, Professional, Role> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional, Role> application)
        {
            s_application = application;
        }

        public static async Task<GetRolesResponse> GetRolesAsync(GetRolesRequest request)
        {
            var newUserCommand = MapToGetRolesCommand(request);
            var data = await s_application.GetRoles(newUserCommand);
            return MapToGetRolesResponse(data);
        }

        private static GetRolesCommand MapToGetRolesCommand(GetRolesRequest request)
        {
            return new GetRolesCommand
            {
                Page = request.Page,
                Limit = request.Limit,
                Filter = request.Filter,
                Sort = request.Sort,
                Order = request.Order
            };
        }

        private static GetRolesResponse MapToGetRolesResponse(
            GetRolesApplicationResponse<Role> data
        )
        {
            return new GetRolesResponse
            {
                 Roles = data
                .Roles.Select(role => new RoleContract
                {
                    RolelId = role.RoleId.ToString(),
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
