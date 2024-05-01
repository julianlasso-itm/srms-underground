using System.Text.Json;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public class UpdateSkillUseCase<TSkillEntity>
    : BaseUseCase<UpdateSkillCommand, UpdateSkillApplicationResponse, IPersonnelAggregateRoot>
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillUpdated}";

    public UpdateSkillUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ISkillRepository<TSkillEntity> skillRepository
    )
      : base(aggregateRoot)
    {
      _skillRepository = skillRepository;
    }

    public override async Task<UpdateSkillApplicationResponse> Handle(UpdateSkillCommand request)
    {
      var dataUpdateSkill = MapToRequestForDomain(request);
      var skill = AggregateRoot.UpdateSkill(dataUpdateSkill);
      var response = MapToResponse(skill);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
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
