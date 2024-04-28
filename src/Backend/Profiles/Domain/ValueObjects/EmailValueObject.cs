using System.ComponentModel.DataAnnotations;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects;

public sealed class EmailValueObject : BaseStringValueObject
{
    private const int MaxLength = 500;

    public EmailValueObject(string value)
        : base(value)
    {
        Name = "Email";
        Validate();
    }

    public override void Validate()
    {
        base.Validate();
        if (!IsEmailValid(Value))
        {
            AddError(new ErrorValueObject(Name, $"{Name} is not a valid email"));
        }
        else if (!IsLengthValid(Value))
        {
            AddError(
                new ErrorValueObject(Name, $"{Name} must be less than {MaxLength} characters")
            );
        }
    }

    private static bool IsLengthValid(string value)
    {
        return value.Length <= MaxLength;
    }

    private static bool IsEmailValid(string value)
    {
        return new EmailAddressAttribute().IsValid(value);
    }
}
