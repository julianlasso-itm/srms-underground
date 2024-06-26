using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  internal class GetSkillsUseCase<TSkillEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ISkillRepository<TSkillEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetSkillsCommand,
      GetSkillsApplicationResponse<TSkillEntity>,
      IPersonnelAggregateRoot,
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
