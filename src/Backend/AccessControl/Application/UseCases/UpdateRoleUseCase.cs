using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Request;
using AccessControl.Domain.Aggregates.Dto.Response;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class UpdateRoleUseCase<TEntity>
    : BaseUseCase<UpdateRoleCommand, UpdateRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleUpdated}";

    public UpdateRoleUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IRoleRepository<TEntity> roleRepository
    )
        : base(aggregateRoot)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request)
    {
        var dataUpdateRole = MapToRequestForDomain(request);
        var role = AggregateRoot.UpdateRole(dataUpdateRole);
        var response = MapToResponse(role);
        _ = await Persist(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private UpdateRoleDomainRequest MapToRequestForDomain(UpdateRoleCommand request)
    {
        return new UpdateRoleDomainRequest
        {
            RoleId = request.RoleId,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable,
        };
    }

    private UpdateRoleResponse MapToResponse(UpdateRoleDomainResponse role)
    {
        return new UpdateRoleResponse
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };
    }

    private async Task<TEntity> Persist(UpdateRoleResponse response)
    {
        return await _roleRepository.UpdateAsync(Guid.Parse(response.RoleId), response);
    }
}
