using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects;

public sealed class ProvinceIdValueObject : BaseIdValueObject
{
    public ProvinceIdValueObject(string value)
        : base(value)
    {
        Name = "ProvinceId";
        Validate();
    }
}
