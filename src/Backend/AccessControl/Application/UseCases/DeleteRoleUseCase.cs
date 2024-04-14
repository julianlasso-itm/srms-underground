using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class DeleteRoleUseCase<TEntity>
    : BaseUseCase<DeleteRoleCommand, DeleteRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;

    public DeleteRoleUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IRoleRepository<TEntity> roleRepository
    )
        : base(aggregateRoot)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<DeleteRoleResponse> Handle(DeleteRoleCommand request)
    {
        var dataDeleteRole = new DeleteRole { RoleId = request.RoleId, };
        var role = AggregateRoot.DeleteRole(dataDeleteRole);

        var response = new DeleteRoleResponse { RoleId = role.RoleId };

        _ = await _roleRepository.SoftDeleteAsync(Guid.Parse(role.RoleId));
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventRoleDeleted}",
            JsonSerializer.Serialize(response)
        );
        return response;
    }
}
