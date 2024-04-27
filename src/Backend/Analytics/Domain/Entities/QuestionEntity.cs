using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;

namespace Analytics.Domain.Entities;

internal sealed class QuestionEntity
{
    public QuestionIdValueObject QuestionId { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public QuestionEntity() { }

    public QuestionEntity(QuestionStruct data)
    {
        QuestionId = data.QuestionId;
        Question = data.Question;
        Disabled = data.Disabled;
    }

    public void Register(
        QuestionValueObject question
    )
    {
        QuestionId = new QuestionIdValueObject(Guid.NewGuid().ToString());
        Question = question;
        Disabled = new DisabledValueObject(false);
    }

    public void Enable()
    {
        Disabled = new DisabledValueObject(false);
    }

    public void Disable()
    {
        Disabled = new DisabledValueObject(true);
    }

    public void UpdateQuestion(QuestionValueObject question)
    {
        Question = question;
    }

    public void DeleteQuestion()
    {
        Question = null;
    }
}
