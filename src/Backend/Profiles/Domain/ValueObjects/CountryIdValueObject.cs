using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects;

public sealed class CountryIdValueObject : BaseIdValueObject
{
    public CountryIdValueObject(string value)
        : base(value)
    {
        Name = "CountryId";
        Validate();
    }
}
