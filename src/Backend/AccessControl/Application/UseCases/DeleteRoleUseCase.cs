using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class DeleteRoleUseCase<TEntity>
    : BaseUseCase<DeleteRoleCommand, DeleteRoleApplicationResponse, ISecurityAggregateRoot>
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

    public override async Task<DeleteRoleApplicationResponse> Handle(DeleteRoleCommand request)
    {
        var dataDeleteRole = MapToRequestForDomain(request);
        var role = AggregateRoot.DeleteRole(dataDeleteRole);
        var response = MapToResponse(role);
        _ = await Persist(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private DeleteRoleDomainRequest MapToRequestForDomain(DeleteRoleCommand request)
    {
        return new DeleteRoleDomainRequest { RoleId = request.RoleId };
    }

    private DeleteRoleApplicationResponse MapToResponse(DeleteRoleDomainResponse role)
    {
        return new DeleteRoleApplicationResponse { RoleId = role.RoleId };
    }

    private async Task<TEntity> Persist(DeleteRoleApplicationResponse response)
    {
        return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
}
