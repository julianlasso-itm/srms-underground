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

public sealed class DeleteProvinceUseCase<TEntity>
    : BaseUseCase<DeleteProvinceCommand, DeleteProvinceApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
{
    private readonly IProvinceRepository<TEntity> _provinceRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventProvinceDeleted}";

    public DeleteProvinceUseCase(
        IPersonnelAggregateRoot aggregateRoot,
        IProvinceRepository<TEntity> provinceRepository
    )
        : base(aggregateRoot)
    {
        _provinceRepository = provinceRepository;
    }

    public override async Task<DeleteProvinceApplicationResponse> Handle(
        DeleteProvinceCommand request
    )
    {
        var dataDeleteProvince = MapToRequestForDomain(request);
        var province = AggregateRoot.DeleteProvince(dataDeleteProvince);
        var response = MapToResponse(province);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
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
