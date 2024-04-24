using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
    public class RegisterSkillHelper : BaseHelper, IHelper<RegisterSkillDomainRequest, RegisterSkillDomainResponse>
    {
        public static RegisterSkillDomainResponse Execute(RegisterSkillDomainRequest data)
        {
            var @struct = GetSkillRole(data);
            ValidateStructureFields(@struct);

            var skill = new SkillEntity();
            skill.Register(@struct.Name);

            return new RegisterSkillDomainResponse
            {
                SkillId = skill.SkillId.Value,
                Name = skill.Name.Value,
                Disabled = skill.Disabled.Value
            };
        }

        private static SkillStruct GetSkillRole(RegisterSkillDomainRequest data)
        {
            var name = new NameValueObject(data.Name);

            return new SkillStruct { Name = name };
        }
    }
}
