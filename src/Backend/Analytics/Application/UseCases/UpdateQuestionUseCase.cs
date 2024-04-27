using System.Text.Json;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Constants;
using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class UpdateQuestionUseCase<TEntity>
    : BaseUseCase<UpdateQuestionCommand, UpdateQuestionApplicationResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IQuestionRepository<TEntity> _questionRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionUpdated}";

    public UpdateQuestionUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IQuestionRepository<TEntity> questionRepository
    )
        : base(aggregateRoot)
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
            Question = request.Question,
            Disable = request.Disable,
        };
    }

    private UpdateQuestionApplicationResponse MapToResponse(UpdateQuestionDomainResponse question)
    {
        return new UpdateQuestionApplicationResponse
        {
            QuestionId = question.QuestionId,
            Question = question.Question,
            Disable = question.Disable,
        };
    }

    private async Task<TEntity> Persistence(UpdateQuestionApplicationResponse response)
    {
        return await _questionRepository.UpdateAsync(Guid.Parse(response.QuestionId), response);
    }
}
