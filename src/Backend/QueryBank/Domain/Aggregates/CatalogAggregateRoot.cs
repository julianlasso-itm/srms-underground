using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Helpers;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace QueryBank.Domain.Aggregates;

public class CatalogAggregateRoot : BaseAggregateRoot, ICatalogAggregateRoot
{
    public CatalogAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterQuestionDomainResponse RegisterQuestion(RegisterQuestionDomainRequest questionData)
    {
        return RegisterQuestionHelper.Execute(questionData);
    }

    public DeleteQuestionDomainResponse DeleteQuestion(DeleteQuestionDomainRequest dataDeleteQuestion)
    {
        return DeleteQuestionHelper.Execute(dataDeleteQuestion);
    }

    public UpdateQuestionDomainResponse UpdateQuestion(UpdateQuestionDomainRequest dataUpdateQuestion)
    {
        return UpdateQuestionHelper.Execute(dataUpdateQuestion);
    }
}
