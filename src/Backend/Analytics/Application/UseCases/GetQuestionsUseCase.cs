using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class GetQuestionUseCase<TEntity>
    : BaseUseCase<GetQuestionsCommand, GetQuestionsApplicationResponse<TEntity>, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IQuestionRepository<TEntity> _questionRepository;

    public GetQuestionsUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IQuestionRepository<TEntity> questionRepository
    )
        : base(aggregateRoot)
    {
        _questionRepository = questionRepository;
    }

    public override async Task<GetQuestionsApplicationResponse<TEntity>> Handle(GetQuestionsCommand request)
    {
        var data = await QueryQuestions(request);
        var count = await QueryQuestionsCount(request);
        var response = MapToResponse(data, count);
        return response;
    }

    private async Task<IEnumerable<TEntity>> QueryQuestions(GetQuestionsCommand request)
    {
        return await _questionRepository.GetWithPaginationAsync(
            request.Page,
            request.Limit,
            request.Sort!,
            request.Order!,
            request.Filter
        );
    }

    private async Task<int> QueryQuestionsCount(GetQuestionsCommand request)
    {
        return await _questionRepository.GetCountAsync(request.Filter);
    }

    private GetQuestionsApplicationResponse<TEntity> MapToResponse(
        IEnumerable<TEntity> questions,
        int total
    )
    {
        return new GetQuestionsApplicationResponse<TEntity> { Questions = questions, Total = total };
    }
}
