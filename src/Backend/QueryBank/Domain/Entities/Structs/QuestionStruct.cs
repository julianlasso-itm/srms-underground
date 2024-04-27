using QueryBank.Domain.ValueObjects;

namespace QueryBank.Domain.Entities.Structs
{
    public struct QuestionStruct
    {

        public QuestionIdValueObject QuestionId { get; set; }
        public NameValueObject Name { get; set; }
        public DisabledValueObject Disabled { get; set; }
    }
}
