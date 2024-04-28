using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
    public class GetProfessionalHelper : BaseHelperServiceInfrastructure
    {
        public static async Task<GetProfessionalResponse> GetProfessionalsAsync(
            GetProfessionalsRequest request
        )
        {
            var newUserCommand = MapToGetProfessionalsCommand(request);
            var data = await Application.GetProfessional(newUserCommand);
            return MapToGetProfessionalsResponse(data);
        }

        private static GetProfessionalsCommand MapToGetProfessionalsCommand(
            GetProfessionalsRequest request
        )
        {
            return new GetProfessionalsCommand
            {
                Page = request.Page,
                Limit = request.Limit,
                Filter = request.Filter,
                Sort = request.Sort,
                Order = request.Order
            };
        }

        private static GetProfessionalResponse MapToGetProfessionalsResponse(
            GetProfessionalsApplicationResponse<ProfessionalModel> data
        )
        {
            return new GetProfessionalResponse
            {
                Professionals = data
                    .Professionals.Select(professional => new ProfessionalContract
                    {
                        ProfessionalId = professional.ProfessionalId.ToString(),
                        Name = professional.Name,
                        Email = professional.Email,
                        Skills = ObtenerSkills(professional.Skills),
                        Disabled = professional.Disabled
                    })
                    .ToList(),
                Total = data.Total
            };
        }

        private static IEnumerable<SkillContract> ObtenerSkills(IEnumerable<SkillModel> skills)
        {
            List<SkillContract> skillsContract = new List<SkillContract>();
            foreach (var skill in skills)
            {
                skillsContract.Add(
                    new SkillContract
                    {
                        SkillId = skill.SkillId.ToString(),
                        Name = skill.Name,
                        Disabled = skill.Disabled
                    }
                );
            }

            return skillsContract;
        }
    }
}
