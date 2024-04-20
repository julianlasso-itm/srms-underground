using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class GetRolesUseCase<TEntity>
    : BaseUseCase<GetRolesCommand, GetRolesResponse<TEntity>, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;

    public GetRolesUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IRoleRepository<TEntity> roleRepository
    )
        : base(aggregateRoot)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<GetRolesResponse<TEntity>> Handle(GetRolesCommand request)
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
            request.Filter
        );
    }

    private async Task<int> QueryRolesCount(GetRolesCommand request)
    {
        return await _roleRepository.GetCountAsync(request.Filter);
    }

    private GetRolesResponse<TEntity> MapToResponse(IEnumerable<TEntity> roles, int total)
    {
        return new GetRolesResponse<TEntity> { Roles = roles, Total = total };
    }
}
