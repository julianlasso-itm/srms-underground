using System.Text.Json;
using System.Threading.Channels;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Profiles.Domain.Entities;
using Profiles.Infrastructure.Services.helpers;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
    public class UpdateProfessionalUseCase<TEntity> : BaseUseCase<UpdateProfessionalCommand, UpdateProfessionalApplicationResponse, IPersonnelAggregateRoot> where TEntity : class
    {
     
        private IProfessionalRepository<TEntity> _professionalRepository;

        private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProfessionalUpdated}";

        public UpdateProfessionalUseCase(IPersonnelAggregateRoot aggregateRoot, IProfessionalRepository<TEntity> professionalRepository): base (aggregateRoot)
        {
            _professionalRepository = professionalRepository;
        }

        public override async Task<UpdateProfessionalApplicationResponse> Handle(UpdateProfessionalCommand request)
        {
            var dataUpdateProfessional = MapToRequestForDomain(request);
            var professional = AggregateRoot.UpdateProfessional(dataUpdateProfessional);
            var response = MapToResponse(professional);
            _ = await Persistence(response);
            EmitEvent(Channel, JsonSerializer.Serialize(response));
            return response;
        }

        private UpdateProfessionalDomainRequest MapToRequestForDomain(UpdateProfessionalCommand request)
        {
            return new UpdateProfessionalDomainRequest
            {
                ProfessionalId = request.ProfessionalId,
                Name = request.Name,
                Email = request.Email,
                Disabled = request.Disabled,
            };
        }

        private UpdateProfessionalApplicationResponse MapToResponse(UpdateProfessionalDomainResponse professional)
        {
            return new UpdateProfessionalApplicationResponse
            {
                ProfessionalId = professional.ProfessionalId,
                Name = professional.Name,
                Email = professional.Email,
                Skills = professional.Skills,
                Disabled = professional.Disabled,
            };
        }

        private async Task<TEntity> Persistence(UpdateProfessionalApplicationResponse response)
        {
            return await _professionalRepository.UpdateAsync(Guid.Parse(response.ProfessionalId), response);
        }
    }
}
