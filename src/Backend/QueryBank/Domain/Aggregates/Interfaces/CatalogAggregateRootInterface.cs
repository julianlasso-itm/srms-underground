using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Interfaces;

public interface ICatalogAggregateRoot : IAggregateRoot
{
    public DeleteQuestionDomainResponse DeleteQuestion(DeleteQuestionDomainRequest dataDeleteQuestion);
    public RegisterQuestionDomainResponse RegisterQuestion(RegisterQuestionDomainRequest questionData);
    public UpdateQuestionDomainResponse UpdateQuestion(UpdateQuestionDomainRequest dataUpdateQuestion);
}
