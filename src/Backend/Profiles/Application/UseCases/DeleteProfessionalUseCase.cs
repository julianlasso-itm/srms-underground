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
  internal class DeleteProfessionalUseCase<TProfessionalEntity>
    : BaseUseCase<
      DeleteProfessionalCommand,
      DeleteProfessionalApplicationResponse,
      IPersonnelAggregateRoot
    >
    where TProfessionalEntity : class
  {
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProfessionalDeleted}";

    public DeleteProfessionalUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      IProfessionalRepository<TProfessionalEntity> professionalRepository
    )
      : base(aggregateRoot)
    {
      _professionalRepository = professionalRepository;
    }

    public override async Task<DeleteProfessionalApplicationResponse> Handle(
      DeleteProfessionalCommand request
    )
    {
      var dataDeleteRole = MapToRequestForDomain(request);
      var role = AggregateRoot.DeleteProfessional(dataDeleteRole);
      var response = MapToResponse(role);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private async Task<TProfessionalEntity> Persistence(
      DeleteProfessionalApplicationResponse response
    )
    {
      return await _professionalRepository.DeleteAsync(Guid.Parse(response.ProfessionalId));
    }

    private DeleteProfessionalDomainRequest MapToRequestForDomain(DeleteProfessionalCommand request)
    {
      return new DeleteProfessionalDomainRequest { ProfessionalId = request.ProfessionalId };
    }

    private DeleteProfessionalApplicationResponse MapToResponse(
      DeleteProfessionalDomainResponse Professional
    )
    {
      return new DeleteProfessionalApplicationResponse
      {
        ProfessionalId = Professional.ProfessionalId
      };
    }
  }
}
