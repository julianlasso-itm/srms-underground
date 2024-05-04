using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class GetCitiesUseCase<TEntity>
    : BaseUseCase<
      GetCitiesCommand,
      GetCitiesApplicationResponse<TEntity>,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly ICityRepository<TEntity> _cityRepository;

    public GetCitiesUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ICityRepository<TEntity> cityRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _cityRepository = cityRepository;
    }

    public override async Task<GetCitiesApplicationResponse<TEntity>> Handle(
      GetCitiesCommand request
    )
    {
      var data = await QueryCities(request);
      var count = await QueryCitiesCount(request);
      var response = MapToResponse(data, count);
      return response;
    }

    private async Task<IEnumerable<TEntity>> QueryCities(GetCitiesCommand request)
    {
      return await _cityRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort!,
        request.Order!,
        request.Filter,
        request.FilterBy
      );
    }

    private async Task<int> QueryCitiesCount(GetCitiesCommand request)
    {
      return await _cityRepository.GetCountAsync(request.Filter, request.FilterBy);
    }

    private static GetCitiesApplicationResponse<TEntity> MapToResponse(
      IEnumerable<TEntity> cities,
      int total
    )
    {
      return new GetCitiesApplicationResponse<TEntity> { Cities = cities, Total = total };
    }
  }
}
