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
  public sealed class UpdateProvinceUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProvinceRepository<TEntity> provinceRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateProvinceCommand,
      UpdateProvinceApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IProvinceRepository<TEntity> _provinceRepository = provinceRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProvinceUpdated}";

    public override async Task<Result<UpdateProvinceApplicationResponse>> Handle(
      UpdateProvinceCommand request
    )
    {
      var newProvince = MapToRequestForDomain(request);
      var province = AggregateRoot.UpdateProvince(newProvince);

      if (province.IsFailure)
      {
        return Response<UpdateProvinceApplicationResponse>.Failure(
          province.Message,
          province.Code,
          province.Details
        );
      }

      var response = MapToResponse(province.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateProvinceApplicationResponse>.Success(response);
    }

    private static UpdateProvinceDomainRequest MapToRequestForDomain(UpdateProvinceCommand request)
    {
      return new UpdateProvinceDomainRequest
      {
        ProvinceId = request.ProvinceId,
        CountryId = request.CountryId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }

    private static UpdateProvinceApplicationResponse MapToResponse(
      UpdateProvinceDomainResponse province
    )
    {
      return new UpdateProvinceApplicationResponse
      {
        ProvinceId = province.ProvinceId,
        CountryId = province.CountryId,
        Name = province.Name,
        Disabled = province.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateProvinceApplicationResponse response)
    {
      return await _provinceRepository.UpdateAsync(Guid.Parse(response.ProvinceId), response);
    }
  }
}
