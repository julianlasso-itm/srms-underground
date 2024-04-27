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

public sealed class DeleteQuestionUseCase<TEntity>
    : BaseUseCase<DeleteQuestionCommand, DeleteQuestionApplicationResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IQuestionRepository<TEntity> _questionRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionDeleted}";

    public DeleteQuestionUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IQuestionRepository<TEntity> questionRepository
    )
        : base(aggregateRoot)
    {
        _questionRepository = questionRepository;
    }

    public override async Task<DeleteQuestionApplicationResponse> Handle(DeleteQuestionCommand request)
    {
        var dataDeleteQuestion = MapToRequestForDomain(request);
        var question = AggregateRoot.DeleteQuestion(dataDeleteQuestion);
        var response = MapToResponse(question);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private DeleteQuestionDomainRequest MapToRequestForDomain(DeleteQuestionCommand request)
    {
        return new DeleteQuestionDomainRequest { QuestionId = request.QuestionId };
    }

    private DeleteQuestionApplicationResponse MapToResponse(DeleteQuestionDomainResponse question)
    {
        return new DeleteQuestionApplicationResponse { QuestionId = question.QuestionId };
    }

    private async Task<TEntity> Persistence(DeleteQuestionApplicationResponse response)
    {
        return await _questionRepository.DeleteAsync(Guid.Parse(response.QuestionId));
    }
}
