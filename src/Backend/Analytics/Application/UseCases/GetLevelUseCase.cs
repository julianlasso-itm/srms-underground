using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class GetQuestionUseCase<TEntity>
    : BaseUseCase<GetLevelCommand, GetLevelApplicationResponse<TEntity>, IAggregateRoot>
    where TEntity : class
{
    private readonly ILevelRepository<TEntity> _questionRepository;

    public GetLevelUseCase(
        IAggregateRoot aggregateRoot,
        ILevelRepository<TEntity> questionRepository
    )
        : base(aggregateRoot)
    {
        _questionRepository = questionRepository;
    }

    public override async Task<GetLevelApplicationResponse<TEntity>> Handle(GetLevelCommand request)
    {
        var data = await QueryLevel(request);
        var count = await QueryLevelCount(request);
        var response = MapToResponse(data, count);
        return response;
    }

    private async Task<IEnumerable<TEntity>> QueryLevel(GetLevelCommand request)
    {
        return await _questionRepository.GetWithPaginationAsync(
            request.Page,
            request.Limit,
            request.Sort!,
            request.Order!,
            request.Filter
        );
    }

    private async Task<int> QueryLevelCount(GetLevelCommand request)
    {
        return await _questionRepository.GetCountAsync(request.Filter);
    }

    private GetLevelApplicationResponse<TEntity> MapToResponse(
        IEnumerable<TEntity> questions,
        int total
    )
    {
        return new GetLevelApplicationResponse<TEntity> { Level = level, Total = total };
    }
}
