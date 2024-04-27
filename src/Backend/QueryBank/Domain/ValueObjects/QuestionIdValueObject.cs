using Shared.Domain.ValueObjects.Base;

namespace QueryBank.Domain.ValueObjects
{
    public class QuestionIdValueObject : BaseIdValueObject
    {

        public QuestionIdValueObject(string value) : base(value)
        {
            Name = "QuestionId";
            Validate();
        }
    }
}
