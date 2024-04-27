using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers;

internal abstract class RegisterQuestionHelper
    : BaseHelper,
        IHelper<RegisterQuestion, RegisterQuestionResponse>
{
    public static RegisterQuestionResponse Execute(RegisterQuestion data)
    {
        var newQuestion = GetQuestionStruct(data);
        ValidateStructureFields(newQuestion);

        var Question = new QuestionEntity();
        Question.Register(newQuestion.Question);

        return new RegisterQuestionResponse
        {
            QuestionId = Question.QuestionId.Value,
            Question = Question.Question.Value,
            Disabled = Question.Disabled.Value,
        };
    }

    public static void Execute()
    {
        throw new NotImplementedException();
    }

    private static QuestionStruct GetQuestionStruct(RegisterQuestion data)
    {
        var question = new NameValueObject(data.Question);

        return new QuestionStruct { Question = question };
    }
}
