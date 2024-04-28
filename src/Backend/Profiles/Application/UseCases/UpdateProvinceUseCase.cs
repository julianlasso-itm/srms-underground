using System.Text.Json;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases;

public sealed class UpdateProvinceUseCase<TEntity>
    : BaseUseCase<UpdateProvinceCommand, UpdateProvinceApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
{
    private readonly IProvinceRepository<TEntity> _provinceRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProvinceUpdated}";

    public UpdateProvinceUseCase(
        IPersonnelAggregateRoot aggregateRoot,
        IProvinceRepository<TEntity> provinceRepository
    )
        : base(aggregateRoot)
    {
        _provinceRepository = provinceRepository;
    }

    public override async Task<UpdateProvinceApplicationResponse> Handle(
        UpdateProvinceCommand request
    )
    {
        var newProvince = MapToRequestForDomain(request);
        var province = AggregateRoot.UpdateProvince(newProvince);
        var response = MapToResponse(province);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
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
