using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class GetRolesUseCase<TEntity>(
    ISecurityAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      GetRolesCommand,
      GetRolesApplicationResponse<TEntity>,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;

    public override async Task<GetRolesApplicationResponse<TEntity>> Handle(GetRolesCommand request)
    {
      var data = await QueryRoles(request);
      var count = await QueryRolesCount(request);
      var response = AclOutputMapper.ToGetRolesApplicationResponse(data, count);
      return response;
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
      return await _roleRepository.GetCountAsync(request.Filter, request.FilterBy);
    }
  }
}
