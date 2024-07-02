using System.Text.Json;
using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public class UpdateProfessionalUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProfessionalRepository<TEntity> professionalRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateProfessionalCommand,
      UpdateProfessionalApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private IProfessionalRepository<TEntity> _professionalRepository = professionalRepository;

    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProfessionalUpdated}";

    public override async Task<Result<UpdateProfessionalApplicationResponse>> Handle(
      UpdateProfessionalCommand request
    )
    {
      var dataUpdateProfessional = MapToRequestForDomain(request);
      var professional = AggregateRoot.UpdateProfessional(dataUpdateProfessional);

      if (professional.IsFailure)
      {
        return Response<UpdateProfessionalApplicationResponse>.Failure(
          professional.Message,
          professional.Code,
          professional.Details
        );
      }

      var response = MapToResponse(professional.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateProfessionalApplicationResponse>.Success(response);
    }

    private UpdateProfessionalDomainRequest MapToRequestForDomain(UpdateProfessionalCommand request)
    {
      return new UpdateProfessionalDomainRequest
      {
        ProfessionalId = request.ProfessionalId,
        Name = request.Name,
        Email = request.Email,
        Disable = request.Disable,
      };
    }

    private UpdateProfessionalApplicationResponse MapToResponse(
      UpdateProfessionalDomainResponse professional
    )
    {
      return new UpdateProfessionalApplicationResponse
      {
        ProfessionalId = professional.ProfessionalId,
        Name = professional.Name,
        Email = professional.Email,
        Disabled = professional.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateProfessionalApplicationResponse response)
    {
      return await _professionalRepository.UpdateAsync(
        Guid.Parse(response.ProfessionalId),
        response
      );
    }
  }
}
