using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
    public class ProfessionalIdValueObject : BaseIdValueObject
    {
        public ProfessionalIdValueObject(string value) : base(value)
        {
            Name = "ProfessionalId";
            Validate();
        }
    }
}
