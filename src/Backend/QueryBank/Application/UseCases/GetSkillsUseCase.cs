using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace QueryBank.Application.UseCases
{
  internal class GetSkillsUseCase<TSkillEntity>
    : BaseUseCase<
      GetSkillsCommand,
      GetSkillsApplicationResponse<TSkillEntity>,
      ICatalogAggregateRoot
    >
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository;

    public GetSkillsUseCase(
      ICatalogAggregateRoot aggregateRoot,
      ISkillRepository<TSkillEntity> skillRepository
    )
      : base(aggregateRoot)
    {
      _skillRepository = skillRepository;
    }

    public override async Task<GetSkillsApplicationResponse<TSkillEntity>> Handle(
      GetSkillsCommand request
    )
    {
      var data = await QuerySkills(request);
      var count = await QuerySkillsCount(request);
      var response = MapToResponse(data, count);
      return response;
    }

    private GetSkillsApplicationResponse<TSkillEntity> MapToResponse(
      IEnumerable<TSkillEntity> data,
      int count
    )
    {
      return new GetSkillsApplicationResponse<TSkillEntity> { Skills = data, Total = count };
    }

    private async Task<int> QuerySkillsCount(GetSkillsCommand request)
    {
      return await _skillRepository.GetCountAsync(request.Filter);
    }

    private async Task<IEnumerable<TSkillEntity>> QuerySkills(GetSkillsCommand request)
    {
      return await _skillRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort!,
        request.Order!,
        request.Filter
      );
    }
  }
}
