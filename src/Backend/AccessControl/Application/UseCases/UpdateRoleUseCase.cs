using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class UpdateRoleUseCase<TEntity>
    : BaseUseCase<
      UpdateRoleCommand,
      UpdateRoleApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleUpdated}";

    public UpdateRoleUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IRoleRepository<TEntity> roleRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _roleRepository = roleRepository;
    }

    public override async Task<UpdateRoleApplicationResponse> Handle(UpdateRoleCommand request)
    {
      var dataUpdateRole = AclInputMapper.ToUpdateRoleDomainRequest(request);
      var role = AggregateRoot.UpdateRole(dataUpdateRole);
      var response = AclOutputMapper.ToUpdateRoleApplicationResponse(role);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private async Task<TEntity> Persistence(UpdateRoleApplicationResponse response)
    {
      return await _roleRepository.UpdateAsync(Guid.Parse(response.RoleId), response);
    }
  }
}
