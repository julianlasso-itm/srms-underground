using AccessControl.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class GetRolesUseCase<TEntity>
    : BaseUseCase<GetRolesCommand, GetRolesApplicationResponse<TEntity>, ISecurityAggregateRoot>
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository;
    private readonly IAntiCorruptionLayer _antiCorruptionLayer;

    public GetRolesUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IRoleRepository<TEntity> roleRepository,
      IAntiCorruptionLayer antiCorruptionLayer
    )
      : base(aggregateRoot)
    {
      _roleRepository = roleRepository;
      _antiCorruptionLayer = antiCorruptionLayer;
    }

    public override async Task<GetRolesApplicationResponse<TEntity>> Handle(GetRolesCommand request)
    {
      var data = await QueryRoles(request);
      var count = await QueryRolesCount(request);
      var response = MapToResponse(data, count);
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

    private GetRolesApplicationResponse<TEntity> MapToResponse(
      IEnumerable<TEntity> roles,
      int total
    )
    {
      return new GetRolesApplicationResponse<TEntity> { Roles = roles, Total = total };
    }
  }
}
