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
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public sealed class DeleteProvinceUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProvinceRepository<TEntity> provinceRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteProvinceCommand,
      DeleteProvinceApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IProvinceRepository<TEntity> _provinceRepository = provinceRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProvinceDeleted}";

    public override async Task<Result<DeleteProvinceApplicationResponse>> Handle(
      DeleteProvinceCommand request
    )
    {
      var dataDeleteProvince = MapToRequestForDomain(request);
      var province = AggregateRoot.DeleteProvince(dataDeleteProvince);

      if (province.IsFailure)
      {
        return Response<DeleteProvinceApplicationResponse>.Failure(
          province.Message,
          province.Code,
          province.Details
        );
      }
      var response = MapToResponse(province.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<DeleteProvinceApplicationResponse>.Success(response);
    }

    private static DeleteProvinceDomainRequest MapToRequestForDomain(DeleteProvinceCommand request)
    {
      return new DeleteProvinceDomainRequest { ProvinceId = request.ProvinceId };
    }

    private static DeleteProvinceApplicationResponse MapToResponse(
      DeleteProvinceDomainResponse province
    )
    {
      return new DeleteProvinceApplicationResponse { ProvinceId = province.ProvinceId };
    }

    private async Task<TEntity> Persistence(DeleteProvinceApplicationResponse response)
    {
      return await _provinceRepository.DeleteAsync(Guid.Parse(response.ProvinceId));
    }
  }
}
