using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Analytics.Domain.ValueObjects;

public class QuestionValueObject : BaseStringValueObject
{
    private const int MaxLength = 150;

    public QuestionValueObject(string value)
        : base(value)
    {
        Question = "Question";
        Validate();
    }

    public sealed override void Validate()
    {
        base.Validate();
        if (!IsLengthValid(Value))
        {
            AddError(
                new ErrorValueObject(Question, $"{Question} must be less than {MaxLength} characters")
            );
        }
    }

    private static bool IsLengthValid(string value)
    {
        return value.Length <= MaxLength;
    }
}
