using QueryBank.Domain.Aggregates.Constants;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates.Interfaces;
using QueryBank.Infrastructure.Services.helpers;
using Shared.Application.Base;
using System.Text.Json;
using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Dto.Responses;

namespace QueryBank.Application.UseCases
{
    public class UpdateQuestionUseCase<TQuestionEntity> : BaseUseCase<UpdateQuestionCommand, UpdateQuestionApplicationResponse, ICatalogAggregateRoot> where TQuestionEntity : class
    {

        private readonly IQuestionRepository<TQuestionEntity> _questionRepository;

        private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionUpdated}";

        public UpdateQuestionUseCase(ICatalogAggregateRoot aggregateRoot, IQuestionRepository<TQuestionEntity> questionRepository) : base(aggregateRoot)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<UpdateQuestionApplicationResponse> Handle(UpdateQuestionCommand request)
        {
            var dataUpdateQuestion = MapToRequestForDomain(request);
            var question = AggregateRoot.UpdateQuestion(dataUpdateQuestion);
            var response = MapToResponse(question);
            _ = await Persistence(response);
            EmitEvent(Channel, JsonSerializer.Serialize(response));
            return response;
        }

        private UpdateQuestionDomainRequest MapToRequestForDomain(UpdateQuestionCommand request)
        {
            return new UpdateQuestionDomainRequest
            {
                QuestionId = request.QuestionId,
                Name = request.Name,
                Disabled = request.Disabled,
            };
        }

        private UpdateQuestionApplicationResponse MapToResponse(UpdateQuestionDomainResponse question)
        {
            throw new System.NotImplementedException();
            // return new UpdateQuestionApplicationResponse
            // {
            //     QuestionId = question.QuestionId,
            //     Name = question.Name,
            //     Disabled = question.Disabled,
            // };
        }

        private async Task<TQuestionEntity> Persistence(UpdateQuestionApplicationResponse response)
        {
            return await _questionRepository.UpdateAsync(Guid.Parse(response.QuestionId), response);
        }
    }
}
