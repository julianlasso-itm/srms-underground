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
    public class RegisterSkillUseCase<TEntity>
        : BaseUseCase<
            RegisterSkillCommand,
            RegisterSkillApplicationResponse,
            IPersonnelAggregateRoot
        >
        where TEntity : class
    {
        private readonly ISkillRepository<TEntity> _skillRepository;

        private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventSkillRegistered}";

        public RegisterSkillUseCase(
            IPersonnelAggregateRoot aggregateRoot,
            ISkillRepository<TEntity> skillRepository
        )
            : base(aggregateRoot)
        {
            _skillRepository = skillRepository;
        }

        public override async Task<RegisterSkillApplicationResponse> Handle(
            RegisterSkillCommand request
        )
        {
            var newSkill = MapToRequestForDomain(request);
            var skill = AggregateRoot.RegisterSkill(newSkill);
            var response = MapToResponse(skill);
            _ = await Persistence(response);
            EmitEvent(Channel, JsonSerializer.Serialize(response));
            return response;
        }

        private RegisterSkillDomainRequest MapToRequestForDomain(RegisterSkillCommand request)
        {
            return new RegisterSkillDomainRequest { Name = request.Name, };
        }

        private RegisterSkillApplicationResponse MapToResponse(RegisterSkillDomainResponse skill)
        {
            return new RegisterSkillApplicationResponse
            {
                SkillId = skill.SkillId,
                Name = skill.Name,
                Disabled = skill.Disabled
            };
        }

        private async Task<TEntity> Persistence(RegisterSkillApplicationResponse response)
        {
            return await _skillRepository.AddAsync(response);
        }
    }
}
