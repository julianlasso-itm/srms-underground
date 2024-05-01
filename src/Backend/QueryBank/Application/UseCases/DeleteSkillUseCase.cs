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
  internal class DeleteSkillUseCase<TSkillEntity>
    : BaseUseCase<DeleteSkillCommand, DeleteSkillApplicationResponse, ICatalogAggregateRoot>
    where TSkillEntity : class
  {
    private ISkillRepository<TSkillEntity> _skillRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillDeleted}";

    public DeleteSkillUseCase(
      ICatalogAggregateRoot aggregateRoot,
      ISkillRepository<TSkillEntity> skillRepository
    )
      : base(aggregateRoot)
    {
      {
        _skillRepository = skillRepository;
      }
    }

    public override async Task<DeleteSkillApplicationResponse> Handle(DeleteSkillCommand request)
    {
      var dataDeleteRole = MapToRequestForDomain(request);
      var role = AggregateRoot.DeleteSkill(dataDeleteRole);
      var response = MapToResponse(role);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private async Task<TSkillEntity> Persistence(DeleteSkillApplicationResponse response)
    {
      return await _skillRepository.DeleteAsync(Guid.Parse(response.SkillId));
    }

    private DeleteSkillDomainRequest MapToRequestForDomain(DeleteSkillCommand request)
    {
      return new DeleteSkillDomainRequest { SkillId = request.SkillId };
    }

    private DeleteSkillApplicationResponse MapToResponse(DeleteSkillDomainResponse skill)
    {
      return new DeleteSkillApplicationResponse { SkillId = skill.SkillId };
    }
  }
}
