using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Application.UseCases;
using Analytics.Domain.Aggregates.Interfaces;

namespace Analytics.Application;

public class Application<TLevelEntity, TQuestionEntity>
    where TQuestionEntity : class
    where TLevelEntity : class
{
    public required IAggregateRoot AggregateRoot { get; init; }

    private readonly IQuestionRepository<TQuestionEntity> _questionRepository;
    private readonly ILevelRepository<TLevelEntity> _levelRepository;

    public Application(
               ILevelRepository<TLevelEntity> levelRepository,
               IQuestionRepository<TQuestionEntity> questionRepository
    )
    {
        _levelRepository = levelRepository;
        _questionRepository = questionRepository;
    }

    public Application(ILevelRepository<TLevelEntity> levelRepository, IQuestionRepository<TQuestionEntity> questionRepository,
    )
    {
        _levelRepository = levelRepository;
        _questionRepository = questionRepository;
    }

    public Task<RegisterLevelApplicationResponse> RegisterLevel(RegisterLevelCommand request)
    {
        var useCase = new RegisterLevelUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterQuestionApplicationResponse> RegisterQuestion(RegisterQuestionCommand request)
    {
        var useCase = new RegisterQuestionUseCase<TQuestionEntity>(AggregateRoot, _questionRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateLevelApplicationResponse> UpdateLevel(UpdateLevelCommand request)
    {
        var useCase = new UpdateLevelUseCase<TLevelEntity>(AggregateRoot, _levelRepository);
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
