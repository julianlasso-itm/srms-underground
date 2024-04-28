using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases;

public sealed class GetProvincesUseCase<TEntity>
    : BaseUseCase<
        GetProvincesCommand,
        GetProvincesApplicationResponse<TEntity>,
        IPersonnelAggregateRoot
    >
    where TEntity : class
{
    private readonly IProvinceRepository<TEntity> _countryRepository;

    public GetProvincesUseCase(
        IPersonnelAggregateRoot aggregateRoot,
        IProvinceRepository<TEntity> countryRepository
    )
        : base(aggregateRoot)
    {
        _countryRepository = countryRepository;
    }

    public override async Task<GetProvincesApplicationResponse<TEntity>> Handle(
        GetProvincesCommand request
    )
    {
        var data = await QueryProvinces(request);
        var count = await QueryProvincesCount(request);
        var response = MapToResponse(data, count);
        return response;
    }

    private async Task<IEnumerable<TEntity>> QueryProvinces(GetProvincesCommand request)
    {
        return await _countryRepository.GetWithPaginationAsync(
            request.Page,
            request.Limit,
            request.Sort!,
            request.Order!,
            request.Filter,
            request.FilterBy
        );
    }

    private async Task<int> QueryProvincesCount(GetProvincesCommand request)
    {
        return await _countryRepository.GetCountAsync(request.Filter, request.FilterBy);
    }

    private static GetProvincesApplicationResponse<TEntity> MapToResponse(
        IEnumerable<TEntity> provinces,
        int total
    )
    {
        return new GetProvincesApplicationResponse<TEntity>
        {
            Provinces = provinces,
            Total = total
        };
    }
}
