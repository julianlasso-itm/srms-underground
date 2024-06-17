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
  public sealed class RegisterProvinceUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IProvinceRepository<TEntity> provinceRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterProvinceCommand,
      RegisterProvinceApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IProvinceRepository<TEntity> _provinceRepository = provinceRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProvinceRegistered}";

    public override async Task<RegisterProvinceApplicationResponse> Handle(
      RegisterProvinceCommand request
    )
    {
      var newProvince = MapToRequestForDomain(request);
      var province = AggregateRoot.RegisterProvince(newProvince);
      var response = MapToResponse(province);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private static RegisterProvinceDomainRequest MapToRequestForDomain(
      RegisterProvinceCommand request
    )
    {
      return new RegisterProvinceDomainRequest
      {
        Name = request.Name,
        CountryId = request.CountryId
      };
    }

    private static RegisterProvinceApplicationResponse MapToResponse(
      RegisterProvinceDomainResponse province
    )
    {
      return new RegisterProvinceApplicationResponse
      {
        ProvinceId = province.ProvinceId,
        CountryId = province.CountryId,
        Name = province.Name,
        Disabled = province.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterProvinceApplicationResponse response)
    {
      return await _provinceRepository.AddAsync(response);
    }
  }
}
