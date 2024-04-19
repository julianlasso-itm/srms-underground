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
        AggregateRoot.GetRoles();
        var data = await _roleRepository.GetWithPaginationAsync(
            request.Page,
            request.Limit,
            request.Sort!,
            request.Order!,
            request.Filter
        );
        var count = await _roleRepository.GetCountAsync(request.Filter);
        var response = new GetRolesResponse<TEntity> { Roles = data, Total = count };
        return response;
    }
}
