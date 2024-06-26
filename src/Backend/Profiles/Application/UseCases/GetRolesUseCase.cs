using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  public sealed class GetRolesUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetRolesCommand,
      GetRolesApplicationResponse<TEntity>,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;

    public override async Task<Result<GetRolesApplicationResponse<TEntity>>> Handle(
      GetRolesCommand request
    )
    {
      var data = await QueryRoles(request);
      var count = await QueryRolesCount(request);
      var response = MapToResponse(data, count);

      return Response<GetRolesApplicationResponse<TEntity>>.Success(response);
    }

    private async Task<IEnumerable<TEntity>> QueryRoles(GetRolesCommand request)
    {
      return await _roleRepository.GetWithPaginationAsync(
        request.Page,
        request.Limit,
        request.Sort!,
        request.Order!,
        request.Filter,
        request.FilterBy
      );
    }

    private async Task<int> QueryRolesCount(GetRolesCommand request)
    {
      return await _roleRepository.GetCountAsync(request.Filter);
    }

    private GetRolesApplicationResponse<TEntity> MapToResponse(
      IEnumerable<TEntity> roles,
      int total
    )
    {
      return new GetRolesApplicationResponse<TEntity> { Roles = roles, Total = total };
    }
  }
}
