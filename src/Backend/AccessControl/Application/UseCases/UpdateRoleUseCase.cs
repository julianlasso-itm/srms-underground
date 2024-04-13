using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases;

public sealed class UpdateRoleUseCase<TEntity>
    : BaseUseCase<UpdateRoleCommand, UpdateRoleResponse, ISecurityAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;

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
        var dataUpdateRole = new Domain.Aggregates.Dto.UpdateRole
        {
            RoleId = request.RoleId,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable,
        };
        var role = AggregateRoot.UpdateRole(dataUpdateRole);

        var response = new UpdateRoleResponse
        {
            RoleId = role.RoleId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };

        _ = await _roleRepository.UpdateAsync(role.RoleId, response);
        EmitEvent(
            $"{EventsConst.Prefix}.{EventsConst.EventRoleUpdated}",
            JsonSerializer.Serialize(response)
        );
        return response;
    }
}
