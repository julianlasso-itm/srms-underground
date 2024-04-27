using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
    public class RoleIdValueObject : BaseIdValueObject
    {
        public RoleIdValueObject(string value)
            : base(value)
        {
            Name = "RoleId";
            Validate();
        }
    }
}
