using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
    public class RegisterProfessionalHelper : BaseHelper, IHelper<RegisterProfessionalDomainRequest, RegisterProfessionalDomainResponse>
    {
        public static RegisterProfessionalDomainResponse Execute(RegisterProfessionalDomainRequest data)
        {
            var @struct = GetProfessional(data);
            ValidateStructureFields(@struct);

            var professional = new ProfessionalEntity();
            professional.Register(@struct.Name, @struct.Email);

            return new RegisterProfessionalDomainResponse
            {
                ProfessionalId = professional.ProfessionalId.Value,
                Name = professional.Name.Value,
                Email = professional.Email,
                Skills = (IEnumerable<SkillStruct>)professional.Skills,
                Disabled = professional.Disabled.Value
            };
        }

        private static ProfessionalStruct GetProfessional(RegisterProfessionalDomainRequest data)
        {

            var name = new NameValueObject(data.Name);

            return new ProfessionalStruct
            {
                Name = name,
                Email = data.Email
            };
        }
    }
}
