using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs
{
    public struct ProfessionalStruct
    {
        public ProfessionalIdValueObject ProfessionalId {  get; set; }
        public DisabledValueObject Disabled { get; set; }
        public NameValueObject Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<SkillEntity> Skills { get; internal set; }
    }
}
