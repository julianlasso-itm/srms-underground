using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.helpers;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class GetSkillsHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<GetSkillsResponse> GetSkillsAsync(GetSkillsRequest request)
        {
            var newUserCommand = MapToGetSkillsCommand(request);
            var data = await Application.GetSkills(newUserCommand);
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
