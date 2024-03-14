namespace Shared.Domain.ValueObjects;

public abstract class IdValueObject : StringValueObject
{
    protected IdValueObject(string value) : base(value) { }

    public override void Validate()
    {
        base.Validate();
        if (!IsUUIDValid(Value))
        {
            AddError(new ErrorValueObject(Name, $"{Name} is not a valid UUID"));
        }
    }

    private bool IsUUIDValid(string value)
    {
        return Guid.TryParse(value, out _);
    }
}
