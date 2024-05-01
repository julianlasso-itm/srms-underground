using System.Text.Json;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Constants;
using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace QueryBank.Application.UseCases
{
  public class UpdateSkillUseCase<TSkillEntity>
    : BaseUseCase<UpdateSkillCommand, UpdateSkillApplicationResponse, ICatalogAggregateRoot>
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillUpdated}";

    public UpdateSkillUseCase(
      ICatalogAggregateRoot aggregateRoot,
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
        SubSkillId = request.SubSkillId,
        Name = request.Name,
        Disabled = request.Disabled,
      };
    }

    private UpdateSkillApplicationResponse MapToResponse(UpdateSkillDomainResponse skill)
    {
      return new UpdateSkillApplicationResponse
      {
        SkillId = skill.SkillId,
        SubSkillId = skill.SubSkillId,
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
