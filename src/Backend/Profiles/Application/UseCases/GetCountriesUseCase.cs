using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public sealed class GetCountriesUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    ICountryRepository<TEntity> countryRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetCountriesCommand,
      GetCountriesApplicationResponse<TEntity>,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly ICountryRepository<TEntity> _countryRepository = countryRepository;

    public override async Task<Result<GetCountriesApplicationResponse<TEntity>>> Handle(
      GetCountriesCommand request
    )
    {
      var data = await QueryCountries(request);
      var count = await QueryCountriesCount(request);
      var response = MapToResponse(data, count);
      return Response<GetCountriesApplicationResponse<TEntity>>.Success(response);
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
