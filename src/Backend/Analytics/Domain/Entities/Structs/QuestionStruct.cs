using Analytics.Domain.ValueObjects;

namespace Analytics.Domain.Entities.Structs;

internal struct QuestionStruct
{
    public QuestionIdValueObject QuestionId { get; set; }
    public QuestionValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
}
