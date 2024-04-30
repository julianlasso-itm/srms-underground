using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases
{
  public sealed class GetLevelsUseCase<TEntity>
    : BaseUseCase<GetLevelsCommand, GetLevelsApplicationResponse<TEntity>, IAggregateRoot>
    where TEntity : class
  {
    private readonly ILevelRepository<TEntity> _levelRepository;

    public GetLevelsUseCase(IAggregateRoot aggregateRoot, ILevelRepository<TEntity> levelRepository)
      : base(aggregateRoot)
    {
      _levelRepository = levelRepository;
    }

    public override async Task<GetLevelsApplicationResponse<TEntity>> Handle(
      GetLevelsCommand request
    )
    {
      var data = await QueryLevels(request);
      var count = await QueryLevelsCount(request);
      var response = MapToResponse(data, count);
      return response;
    }

    private async Task<IEnumerable<TEntity>> QueryLevels(GetLevelsCommand request)
    {
      return await _levelRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort!,
        request.Order!,
        request.Filter,
        request.FilterBy
      );
    }

    private async Task<int> QueryLevelsCount(GetLevelsCommand request)
    {
      return await _levelRepository.GetCountAsync(request.Filter, request.FilterBy);
    }

    private GetLevelsApplicationResponse<TEntity> MapToResponse(
      IEnumerable<TEntity> levels,
      int total
    )
    {
      return new GetLevelsApplicationResponse<TEntity> { Levels = levels, Total = total };
    }
  }
}
