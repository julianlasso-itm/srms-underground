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
  internal class DeleteProfessionalUseCase<TProfessionalEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProfessionalRepository<TProfessionalEntity> professionalRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteProfessionalCommand,
      DeleteProfessionalApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TProfessionalEntity : class
  {
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository =
      professionalRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProfessionalDeleted}";

    public override async Task<Result<DeleteProfessionalApplicationResponse>> Handle(
      DeleteProfessionalCommand request
    )
    {
      var dataDeleteRole = MapToRequestForDomain(request);
      var role = AggregateRoot.DeleteProfessional(dataDeleteRole);

      if (role.IsFailure)
      {
        return Response<DeleteProfessionalApplicationResponse>.Failure(
          role.Message,
          role.Code,
          role.Details
        );
      }

      var response = MapToResponse(role.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<DeleteProfessionalApplicationResponse>.Success(response);
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
      DeleteProfessionalDomainResponse professional
    )
    {
      return new DeleteProfessionalApplicationResponse
      {
        ProfessionalId = professional.ProfessionalId
      };
    }
  }
}
