using System.Text.Json;
using AccessControl.Domain.Aggregates.Dto.Requests;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Constants;
using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace QueryBank.Application.UseCases
{
    internal class DeleteQuestionUseCase<TQuestionEntity> : BaseUseCase<DeleteQuestionCommand, DeleteQuestionApplicationResponse, ICatalogAggregateRoot> 
        where TQuestionEntity : class
    {

        private IQuestionRepository<TQuestionEntity> _questionRepository;
        private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionDeleted}";

        public DeleteQuestionUseCase(ICatalogAggregateRoot aggregateRoot, IQuestionRepository<TQuestionEntity> questionRepository) : base(aggregateRoot)
        {
            {
                _questionRepository = questionRepository;
            }
        }

        public override async Task<DeleteQuestionApplicationResponse> Handle(DeleteQuestionCommand request)
        {
            var dataDeleteRole = MapToRequestForDomain(request);
            var question = AggregateRoot.DeleteQuestion(dataDeleteQuestion);
            var response = MapToResponse(question);
            _ = await Persistence(response);
            EmitEvent(Channel, JsonSerializer.Serialize(response));
            return response;
        }

        private async Task<TQuestionEntity> Persistence(DeleteQuestionApplicationResponse response)
        {
            return await _skillRepository.DeleteAsync(Guid.Parse(response.QuestionId));
        }

        private DeleteQuestionDomainRequest MapToRequestForDomain(DeleteQuestionCommand request)
        {
            return new DeleteQuestionDomainRequest { QuestionId = request.QuestionId };
        }

        private DeleteQuestionApplicationResponse MapToResponse(DeleteQuestionDomainResponse question)
        {
            return new DeleteQuestionApplicationResponse { QuestionId = question.QuestionId };
        }

    }

}
