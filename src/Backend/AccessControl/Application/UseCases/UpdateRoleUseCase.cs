using System.Text.Json;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class UpdateRoleUseCase<TEntity>
    : BaseUseCase<UpdateRoleCommand, UpdateRoleApplicationResponse, ISecurityAggregateRoot>
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

    public override async Task<UpdateRoleApplicationResponse> Handle(UpdateRoleCommand request)
    {
      var dataUpdateRole = MapToRequestForDomain(request);
      var role = AggregateRoot.UpdateRole(dataUpdateRole);
      var response = MapToResponse(role);
      _ = await Persistence(response);
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

    private UpdateRoleApplicationResponse MapToResponse(UpdateRoleDomainResponse role)
    {
      return new UpdateRoleApplicationResponse
      {
        RoleId = role.RoleId,
        Name = role.Name,
        Description = role.Description,
        Disabled = role.Disabled,
      };
    }

    private async Task<TEntity> Persistence(UpdateRoleApplicationResponse response)
    {
      return await _roleRepository.UpdateAsync(Guid.Parse(response.RoleId), response);
    }
  }
}
