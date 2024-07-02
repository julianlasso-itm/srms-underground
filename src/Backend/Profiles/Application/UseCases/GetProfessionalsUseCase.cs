using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace Profiles.Application.UseCases
{
  internal class GetProfessionalsUseCase<TProfessionalEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProfessionalRepository<TProfessionalEntity> professionalRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetProfessionalsCommand,
      GetProfessionalsApplicationResponse<TProfessionalEntity>,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TProfessionalEntity : class
  {
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository =
      professionalRepository;

    public override async Task<
      Result<GetProfessionalsApplicationResponse<TProfessionalEntity>>
    > Handle(GetProfessionalsCommand request)
    {
      var data = await QueryProfessionals(request);
      var count = await QueryProfessionalsCount(request);
      var response = MapToResponse(data, count);

      return Response<GetProfessionalsApplicationResponse<TProfessionalEntity>>.Success(response);
    }

    private GetProfessionalsApplicationResponse<TProfessionalEntity> MapToResponse(
      IEnumerable<TProfessionalEntity> data,
      int count
    )
    {
      return new GetProfessionalsApplicationResponse<TProfessionalEntity>
      {
        Professionals = data,
        Total = count
      };
    }

    private async Task<int> QueryProfessionalsCount(GetProfessionalsCommand request)
    {
      return await _professionalRepository.GetCountAsync(request.Filter);
    }

    private async Task<IEnumerable<TProfessionalEntity>> QueryProfessionals(
      GetProfessionalsCommand request
    )
    {
      return await _professionalRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort!,
        request.Order!,
        request.Filter
      );
    }
  }
}
