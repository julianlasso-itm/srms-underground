using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;

namespace QueryBank.Domain.Entities;

internal sealed class QuestionEntity
{
    public QuestionIdValueObject QuestionId { get; private set; }
    public NameValueObject Name { get; private set; }
    public DisabledValueObject Disabled { get; private set; }

    public QuestionEntity() { }

    public QuestionEntity(QuestionStruct data)
    {
        QuestionId = data.QuestionId;
        Name = data.Name;
        Disabled = data.Disabled;
    }

    public void Register(NameValueObject name)
    {
        QuestionId = new QuestionIdValueObject(Guid.NewGuid().ToString());
        Name = name;
    }

    public void Enable()
    {
        Disabled = new DisabledValueObject(false);
    }

    public void Disable()
    {
        Disabled = new DisabledValueObject(true);
    }

    public void UpdateName(NameValueObject name)
    {
        Name = name;
    }
}
