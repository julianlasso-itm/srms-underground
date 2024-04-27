using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
    public class RegisterQuestionUseCase<TEntity> : BaseUseCase<RegisterQuestionCommand, RegisterQuestionApplicationResponse, ICatalogAggregateRoot> 
        where TEntity : class
    {

        private readonly IQuestionRepository<TEntity> _questionRepository;

        private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionRegistered}";

        public RegisterQuestionUseCase(ICatalogAggregateRoot aggregateRoot, IQuestionRepository<TEntity> questionRepository) : base(aggregateRoot)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<RegisterQuestionApplicationResponse> Handle(RegisterQuestionCommand request)
        {
            var newQuestion = MapToRequestForDomain(request);
            var question = AggregateRoot.RegisterQuestion(newQuestion);
            var response = MapToResponse(question);
            _ = await Persistence(response);
            EmitEvent(Channel, JsonSerializer.Serialize(response));
            return response;
        }

        private RegisterQuestionDomainRequest MapToRequestForDomain(RegisterQuestionCommand request)
        {
            return new RegisterQuestionDomainRequest
            {
                Name = request.Name,
            };
        }

        private RegisterQuestionApplicationResponse MapToResponse(RegisterQuestionDomainResponse question)
        {
            return new RegisterQuestionApplicationResponse
            {
                QuestionId = question.QuestionId,
                Name = question.Name,
                Disabled = question.Disabled
            };
        }

        private async Task<TEntity> Persistence(RegisterQuestionApplicationResponse response)
        {
            return await _questionRepository.AddAsync(response);
        }
    }
}
