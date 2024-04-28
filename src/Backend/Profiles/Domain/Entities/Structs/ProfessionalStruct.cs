using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs
{
    public struct ProfessionalStruct
    {
        public ProfessionalIdValueObject ProfessionalId { get; set; }
        public DisabledValueObject Disabled { get; set; }
        public NameValueObject Name { get; set; }
        public EmailValueObject Email { get; set; }
    }
}
