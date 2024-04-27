using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Application.UseCases;
using Analytics.Domain.Aggregates.Interfaces;

namespace Analytics.Application;

public class Application<TQuestionEntity>
    where TQuestionEntity : class
{
    public required ISecurityAggregateRoot AggregateRoot { get; init; }

    private readonly IQuestionRepository<TQuestionEntity> _questionRepository;

    public Application(
        IQuestionRepository<TQuestionEntity> questionRepository,
    )
    {
        _questionRepository = questionRepository;
    }

    public Task<RegisterQuestionApplicationResponse> RegisterQuestion(RegisterQuestionCommand request)
    {
        var useCase = new RegisterQuestionUseCase<TQuestionEntity>(AggregateRoot, _questionRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateQuestionApplicationResponse> UpdateQuestion(UpdateQuestionCommand request)
    {
        var useCase = new UpdateQuestionUseCase<TQuestionEntity>(AggregateRoot, _questionRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteQuestionApplicationResponse> DeleteQuestion(DeleteQuestionCommand request)
    {
        var useCase = new DeleteQuestionUseCase<TQuestionEntity>(AggregateRoot, _questionRepository);
        return useCase.Handle(request);
    }

    public Task<GetQuestionsApplicationResponse<TQuestionEntity>> GetQuestions(GetQuestionsCommand request)
    {
        var useCase = new GetQuestionsUseCase<TQuestionEntity>(AggregateRoot, _questionRepository);
        return useCase.Handle(request);
    }
}
