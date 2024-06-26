using System.Text.Json;
using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  public class UpdateSkillUseCase<TSkillEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ISkillRepository<TSkillEntity> skillRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateSkillCommand,
      UpdateSkillApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository = skillRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillUpdated}";

    public override async Task<Result<UpdateSkillApplicationResponse>> Handle(
      UpdateSkillCommand request
    )
    {
      var dataUpdateSkill = MapToRequestForDomain(request);
      var skill = AggregateRoot.UpdateSkill(dataUpdateSkill);

      if (skill.IsFailure)
      {
        return Response<UpdateSkillApplicationResponse>.Failure(
          skill.Message,
          skill.Code,
          skill.Details
        );
      }
      var response = MapToResponse(skill.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateSkillApplicationResponse>.Success(response);
    }

    private UpdateSkillDomainRequest MapToRequestForDomain(UpdateSkillCommand request)
    {
      return new UpdateSkillDomainRequest
      {
        SkillId = request.SkillId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }

    private UpdateSkillApplicationResponse MapToResponse(UpdateSkillDomainResponse skill)
    {
      return new UpdateSkillApplicationResponse
      {
        SkillId = skill.SkillId,
        Name = skill.Name,
        Disabled = skill.Disabled,
      };
    }

    private async Task<TSkillEntity> Persistence(UpdateSkillApplicationResponse response)
    {
      return await _skillRepository.UpdateAsync(Guid.Parse(response.SkillId), response);
    }
  }
}
