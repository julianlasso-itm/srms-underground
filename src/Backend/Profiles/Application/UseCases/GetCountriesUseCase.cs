using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class GetCountriesUseCase<TEntity>
    : BaseUseCase<
      GetCountriesCommand,
      GetCountriesApplicationResponse<TEntity>,
      IPersonnelAggregateRoot
    >
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository;

    public GetCountriesUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      ICountryRepository<TEntity> countryRepository
    )
      : base(aggregateRoot)
    {
      _countryRepository = countryRepository;
    }

    public override async Task<GetCountriesApplicationResponse<TEntity>> Handle(
      GetCountriesCommand request
    )
    {
      var data = await QueryCountries(request);
      var count = await QueryCountriesCount(request);
      var response = MapToResponse(data, count);
      return response;
    }

    private async Task<IEnumerable<TEntity>> QueryCountries(GetCountriesCommand request)
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

    private async Task<int> QueryCountriesCount(GetCountriesCommand request)
    {
      return await _countryRepository.GetCountAsync(request.Filter, request.FilterBy);
    }

    private static GetCountriesApplicationResponse<TEntity> MapToResponse(
      IEnumerable<TEntity> countries,
      int total
    )
    {
      return new GetCountriesApplicationResponse<TEntity> { Countries = countries, Total = total };
    }
  }
}
