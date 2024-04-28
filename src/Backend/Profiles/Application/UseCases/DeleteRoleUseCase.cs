using System.Text.Json;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases;

public sealed class DeleteRoleUseCase<TEntity>
    : BaseUseCase<DeleteRoleCommand, DeleteRoleApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
{
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleDeleted}";

    public DeleteRoleUseCase(
        IPersonnelAggregateRoot aggregateRoot,
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
        _ = await Persistence(response);
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

    private async Task<TEntity> Persistence(DeleteRoleApplicationResponse response)
    {
        return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
}
