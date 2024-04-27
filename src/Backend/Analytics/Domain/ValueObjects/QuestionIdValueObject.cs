using Shared.Domain.ValueObjects.Base;

namespace Analytics.Domain.ValueObjects;

public class QuestionIdValueObject : BaseIdValueObject
{
    public QuestionIdValueObject(string value)
        : base(value)
    {
        Name = "QuestionId";
        Validate();
    }
}
