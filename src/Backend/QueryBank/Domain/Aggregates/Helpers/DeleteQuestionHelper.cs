using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers;

internal abstract class DeleteQuestionHelper
    : BaseHelper,
        IHelper<DeleteQuestionDomainRequest, DeleteQuestionDomainResponse>
{
    public static DeleteQuestionDomainResponse Execute(DeleteQuestionDomainRequest request)
    {
        throw new NotImplementedException();
        // var @struct = GetQuestionStruct(request);
        // ValidateStructureFields(@struct);
        // return new DeleteQuestionDomainResponse { QuestionId = @struct.QuestionId.Value };
    }

    private static QuestionStruct GetQuestionStruct(DeleteQuestionDomainRequest request)
    {
        var id = new QuestionIdValueObject(request.QuestionId);
        return new QuestionStruct { QuestionId = id };
    }
}
