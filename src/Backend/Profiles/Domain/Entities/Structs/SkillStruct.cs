using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs
{
    public struct SkillStruct
    {
        public SkillIdValueObject SkillId { get; set; }
        public NameValueObject Name { get; set; }
        public DisabledValueObject Disabled { get; set; }
    }
}
