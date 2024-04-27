using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Entities;
using Analytics.Domain.Entities.Structs;
using Analytics.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Helpers;

internal abstract class UpdateQuestionHelper : BaseHelper, IHelper<UpdateQuestion, UpdateQuestionResponse>
{
    public static UpdateQuestionResponse Execute(UpdateQuestion data)
    {
        var updateQuestion = GetQuestionStruct(data);
        ValidateStructureFields(updateQuestion);

        var question = new QuestionEntity(new QuestionStruct { QuestionId = updateQuestion.QuestionId });
        question.UpdateQuestion(updateQuestion.Question);

        if (updateQuestion.Disabled != null)
        {
            if (updateQuestion.Disabled.Value)
            {
                question.Disable();
            }
            else
            {
                question.Enable();
            }
        }

        return new UpdateQuestionResponse
        {
            QuestionId = question.QuestionId.Value,
            Question = question.Question.Value,
            Disabled = question.Disabled.Value,
        };
    }

    public static void Execute()
    {
        throw new NotImplementedException();
    }

    private static QuestionStruct GetQuestionStruct(UpdateQuestion data)
    {
        var response = new QuestionStruct();
        response.QuestionId = new QuestionIdValueObject(data.QuestionId);

        if (data.Question != null)
        {
            response.Question = new QuestionValueObject(data.Question);
            ;
        }

        if (data.Disabled != null)
        {
            response.Disabled = new DisabledValueObject((bool)data.Disabled);
        }

        return response;
    }
}
