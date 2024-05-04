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

namespace Profiles.Application.UseCases
{
  public class RegisterProfessionalUseCase<TProfessionalEntity>
    : BaseUseCase<
      RegisterProfessionalCommand,
      RegisterProfessionalApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TProfessionalEntity : class
  {
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository;

    private const string Channel =
      $"{EventsConst.Prefix}.{EventsConst.EventProfessionalRegistered}";

    public RegisterProfessionalUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      IProfessionalRepository<TProfessionalEntity> professionalRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _professionalRepository = professionalRepository;
    }

    public override async Task<RegisterProfessionalApplicationResponse> Handle(
      RegisterProfessionalCommand request
    )
    {
      var newProfessional = MapToRequestForDomain(request);
      var professional = AggregateRoot.RegisterProfessional(newProfessional);
      var response = MapToResponse(professional);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private RegisterProfessionalDomainRequest MapToRequestForDomain(
      RegisterProfessionalCommand request
    )
    {
      return new RegisterProfessionalDomainRequest { Name = request.Name, Email = request.Email, };
    }

    private RegisterProfessionalApplicationResponse MapToResponse(
      RegisterProfessionalDomainResponse professional
    )
    {
      return new RegisterProfessionalApplicationResponse
      {
        ProfessionalId = professional.ProfessionalId,
        Name = professional.Name,
        Email = professional.Email,
        Disabled = professional.Disabled
      };
    }

    private async Task<TProfessionalEntity> Persistence(
      RegisterProfessionalApplicationResponse response
    )
    {
      return await _professionalRepository.AddAsync(response);
    }
  }
}
