namespace QueryBank.Domain.Aggregates.Constants;

public abstract class EventsConst
{
    public const string Prefix = "QueryBank";

    public const string EventQuestionRegistered = "QuestionRegistered";
    public const string EventQuestionDeleted = "QuestionDeleted";
    public const string EventQuestionUpdated = "QuestionUpdated";

}
