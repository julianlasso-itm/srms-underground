// Licensed to the .NET Foundation under one or more agreements.

using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Application;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.helpers
{
    public class GetSkillsHelper
    {
        private static Application<Country, State, City, Skill, Professional> s_application;

        public static void SetApplication(Application<Country, State, City, Skill, Professional> application)
        {
            s_application = application;
        }

        public static async Task<GetSkillsResponse> GetSkillsAsync(GetSkillsRequest request)
        {
            var newUserCommand = MapToGetSkillsCommand(request);
            var data = await s_application.GetSkills(newUserCommand);
            return MapToGetSkillsResponse(data);
        }

        private static GetSkillsCommand MapToGetSkillsCommand(GetSkillsRequest request)
        {
            return new GetSkillsCommand
            {
                Page = request.Page,
                Limit = request.Limit,
                Filter = request.Filter,
                Sort = request.Sort,
                Order = request.Order
            };
        }

        private static GetSkillsResponse MapToGetSkillsResponse(
            GetSkillsApplicationResponse<Skill> data
        )
        {
            return new GetSkillsResponse
            {
                Skills = data
                .Skills.Select(skill => new SkillContract
                {
                    SkillId = skill.SkillId.ToString(),
                    Name = skill.Name,
                    Disabled = skill.Disabled
                })
                .ToList(),
                Total = data.Total
            };
        }

    }
}
