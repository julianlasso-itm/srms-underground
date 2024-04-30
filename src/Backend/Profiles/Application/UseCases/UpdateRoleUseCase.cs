using System.Text.Json;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class UpdateRoleUseCase<TEntity>
    : BaseUseCase<UpdateRoleCommand, UpdateRoleApplicationResponse, IPersonnelAggregateRoot>
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleUpdated}";

    public UpdateRoleUseCase(
      IPersonnelAggregateRoot aggregateRoot,
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
