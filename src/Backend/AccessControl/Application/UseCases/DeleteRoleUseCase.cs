using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class DeleteRoleUseCase<TEntity>
    : BaseUseCase<DeleteRoleCommand, DeleteRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleDeleted}";

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
        var dataDeleteRole = MapToRequestForDomain(request);
        var role = AggregateRoot.DeleteRole(dataDeleteRole);
        var response = MapToResponse(role);
        _ = await Persist(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private Domain.Aggregates.Dto.DeleteRoleRequest MapToRequestForDomain(DeleteRoleCommand request)
    {
        return new Domain.Aggregates.Dto.DeleteRoleRequest { RoleId = request.RoleId };
    }

    private DeleteRoleResponse MapToResponse(Domain.Aggregates.Dto.DeleteRoleResponse role)
    {
        return new DeleteRoleResponse { RoleId = role.RoleId };
    }

    private async Task<TEntity> Persist(DeleteRoleResponse response)
    {
        return await _roleRepository.SoftDeleteAsync(Guid.Parse(response.RoleId));
    }
}
