using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
    public class ProfessionalEntity
    {

        public ProfessionalIdValueObject ProfessionalId { get; set; }
        public NameValueObject Name { get; set; }
        public DisabledValueObject Disabled { get; set; }
        public string Email { get; set; }
        public IEnumerable<SkillEntity> Skills { get; set; }

        public ProfessionalEntity()
        {
        }

        public ProfessionalEntity(ProfessionalStruct data)
        {
            ProfessionalId = data.ProfessionalId;
            Name = data.Name;
            Email = data.Email;
            Skills = data.Skills;
            Disabled = data.Disabled;
        }

        public void Register(NameValueObject name, string email)
        {
            ProfessionalId = new ProfessionalIdValueObject(Guid.NewGuid().ToString());
            Email = email;
            Name = name;
            Disabled = new DisabledValueObject(false);
        }

        public void Enable()
        {
            Disabled = new DisabledValueObject(false);
        }

        public void Disable()
        {
            Disabled = new DisabledValueObject(true);
        }

        public void UpdateName(NameValueObject name)
        {
            Name = name;
        }
    }
}
