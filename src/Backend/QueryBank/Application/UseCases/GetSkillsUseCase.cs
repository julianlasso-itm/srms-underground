using QueryBank.Application.AntiCorruption.Interfaces;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common;

namespace QueryBank.Application.UseCases
{
  internal class GetSkillsUseCase<TSkillEntity>(
    ICatalogAggregateRoot aggregateRoot,
    ISkillRepository<TSkillEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetSkillsCommand,
      GetSkillsApplicationResponse<TSkillEntity>,
      ICatalogAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository = skillRepository;

    public override async Task<Result<GetSkillsApplicationResponse<TSkillEntity>>> Handle(
      GetSkillsCommand request
    )
    {
      var data = await QuerySkills(request);
      var count = await QuerySkillsCount(request);
      var response = MapToResponse(data, count);
      return Response<GetSkillsApplicationResponse<TSkillEntity>>.Success(response);
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
